Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class panel
    Dim conn As MySqlConnection
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder

    Dim tx_usuario As String
    Dim tx_clave As String
    Dim tx_servidor As String
    Dim tx_raiz As String

    Dim SettingName As String
    Dim NewString As String
    Dim OriginalString As String

    Dim ue As New System.Text.UTF8Encoding
    Dim sec As New RSACryptoServiceProvider
    Dim bytString(), bytEncriptar(), bytDesEncriptar() As Byte




    Private Sub Conectarse()
        ' Datos de acceso al servidor
        Dim Server As String = servidor.Text
        Dim UserId As String = usuario.Text
        Dim Password As String = clave.Text
        Dim connStr As String
        connStr = String.Format("server={0};user id={1}; password={2};  pooling=false", Server, UserId, Password)
        Try
            conn = New MySqlConnection(connStr)
            conn.Open()
            logs.Text = "Conectado al servidor" & vbCrLf & logs.Text
            GetDatabases()
        Catch ex As MySqlException
            logs.Text = "Error de conexión al servidor" & vbCrLf & logs.Text
        End Try
    End Sub

    Private Sub GetDatabases()
        Dim Ruta As String = "MBM.bat"
        Dim Crea_Archivo As New IO.StreamWriter(Ruta, False)
        Crea_Archivo.Close()
        Dim Archivo As New System.IO.StreamWriter(Ruta)
        Dim reader As MySqlDataReader
        reader = Nothing
        Dim cmd As New MySqlCommand("SHOW DATABASES", conn)
        Dim str_base As String = ""
        Try
            reader = cmd.ExecuteReader()
            Lista_BD.Items.Clear()



            Archivo.WriteLine("@echo off")

            Archivo.WriteLine("setlocal")
            Archivo.WriteLine("set FECHA_ACTUAL=%DATE%")
            Archivo.WriteLine("set HORA_ACTUAL=%TIME%")

            Archivo.WriteLine("set ANO=%FECHA_ACTUAL:~8,2%")
            Archivo.WriteLine("set MES=%FECHA_ACTUAL:~3,2%")
            Archivo.WriteLine("set DIA=%FECHA_ACTUAL:~0,2%")
            Archivo.WriteLine("set HORA=%HORA_ACTUAL:~0,2%")
            Archivo.WriteLine("set MINUTOS=%HORA_ACTUAL:~3,2%")

            While (reader.Read())
                If reader.GetString(0) <> "information_schema" Then

                    Lista_BD.Items.Add(reader.GetString(0))
                    str_base = "mysqldump -h " & servidor.Text & " -u " & usuario.Text & " -p" & clave.Text & " " & reader.GetString(0) & " > "
                    str_base = str_base & """" & raiz_respaldo.Text & "\" & "%DIA%%MES%%ANO%_%HORA%%MINUTOS%_" & reader.GetString(0) & ".sql"""
                    Archivo.WriteLine(str_base)
                End If
            End While
            Archivo.WriteLine("del MBM.bat")
            Archivo.Close()
            logs.Text = "Script creado" & vbCrLf & logs.Text
            conn.Close()
            Shell(Ruta)
            logs.Text = "Script ejecutado" & vbCrLf & logs.Text
            Me.Close()
        Catch ex As MySqlException
            logs.Text = "Error al crear el script" & vbCrLf & logs.Text
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub

    Private Sub Lista_Servidores_MySql_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        splash.Visible = True
        timer_inicial.Start()
    End Sub

    Private Sub boton_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_guardar.Click
        crear_nuevo_ini()
    End Sub

    Private Sub crear_nuevo_ini()
        Try
            Dim Ruta As String = "Config.ini"
            Dim Crea_Archivo As New IO.StreamWriter(Ruta, False)
            Crea_Archivo.Close()
            Dim Archivo As New System.IO.StreamWriter(Ruta)
            Archivo.WriteLine("[Servidor] " & servidor.Text)
            Archivo.WriteLine("[Usuario] " & usuario.Text)
            Archivo.WriteLine("[Clave] " & enc(clave.Text))
            Archivo.WriteLine("[Raiz] " & raiz_respaldo.Text)
            Archivo.WriteLine("[Autocrear] " & autocrear.Checked)
            Archivo.WriteLine("[Finalizar] " & finalizar.Checked)

            Archivo.Close()

            logs.Text = "Configuracion guardada" & vbCrLf & logs.Text
        Catch ex As MySqlException
            logs.Text = "Error al crear el archivo de configuracion" & vbCrLf & logs.Text
        End Try

    End Sub

    ' ##################################################################### Clases Base

    Public Function Cargar_Configuracion() As Boolean
        Dim ConfigFile As New StreamReader("Config.ini")
        Try

            Do
                OriginalString = ConfigFile.ReadLine()
                If OriginalString Is Nothing Then
                    Exit Do
                Else
                    'Get the value of the Setting Name
                    Dim SettingName As String = OriginalString.Remove(0, OriginalString.IndexOf("[") + 1)
                    SettingName = SettingName.Substring(0, SettingName.IndexOf("]"))
                    'Get the value of the Setting Name's  configuration Value
                    NewString = OriginalString.Remove(0, OriginalString.IndexOf("] ") + 1)

                    Select Case SettingName
                        Case "Servidor"
                            servidor.Text = Trim(NewString)
                        Case "Usuario"
                            usuario.Text = Trim(NewString)
                        Case "Clave"
                            clave.Text = dec(Trim(NewString))
                        Case "Raiz"
                            raiz_respaldo.Text = Trim(NewString)
                        Case "Autocrear"
                            autocrear.Checked = Trim(NewString)
                        Case "Finalizar"
                            finalizar.Checked = Trim(NewString)
                    End Select
                End If
            Loop
            logs.Text = "Configuracion cargada" & vbCrLf & logs.Text
            ConfigFile.Close()
        Catch
            logs.Text = "Error al cargar la configuracion" & vbCrLf & logs.Text
            ConfigFile.Close()
        End Try
    End Function
    '*************************************************************************************
    Protected key As String = "&/?@*>:>"


    Public Function enc(ByVal strtext As String) As String
        Return encc(strtext, key)
    End Function

    Public Function dec(ByVal strtext As String) As String
        Return decc(strtext, key)
    End Function

    ' Funcion que encripta cadenas
    Private Function encc(ByVal strText As String, ByVal strEncrKey As String) As String
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Microsoft.VisualBasic.Left(strEncrKey, 8))

            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    'Funcion que desencripta cadenas
    Private Function decc(ByVal strText As String, ByVal sDecrKey _
                   As String) As String
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(strText.Length) As Byte

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Microsoft.VisualBasic.Left(sDecrKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

            Return encoding.GetString(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    Private Sub examinar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles examinar.Click
        Dim examinar_raiz As New System.Windows.Forms.FolderBrowserDialog
        examinar_raiz.Description = "Raiz de trabajo:"
        ' Sets the root folder where the browsing starts from
        'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments
        examinar_raiz.RootFolder = Environment.SpecialFolder.MyComputer
        examinar_raiz.ShowNewFolderButton = True
        Dim dlgResult As DialogResult = examinar_raiz.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            raiz_respaldo.Text = examinar_raiz.SelectedPath
        End If
    End Sub

    Private Sub regenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regenerar.Click
        Cargar_Configuracion()
        Conectarse()
    End Sub

    Private Sub timer_inicial_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_inicial.Tick
        If File.Exists("Config.ini") Then
            Cargar_Configuracion()
        Else
            crear_configuracion_basica()
            Cargar_Configuracion()
        End If

        If autocrear.Checked = True Then
            Conectarse()
        End If
        timer_inicial.Stop()
        splash.Visible = False
        Me.Visible = True
    End Sub

    Function crear_configuracion_basica() As Boolean
        Dim Ruta As String = "Config.ini"
        Dim Crea_Archivo As New IO.StreamWriter(Ruta, False)
        Crea_Archivo.Close()
        Dim Archivo As New System.IO.StreamWriter(Ruta)
        Archivo.WriteLine("[Servidor] localhost")
        Archivo.WriteLine("[Usuario] root")
        Archivo.WriteLine("[Clave] " & enc("root"))
        Archivo.WriteLine("[Raiz] " & CurDir())
        Archivo.WriteLine("[Autocrear] False")
        Archivo.WriteLine("[Finalizar] True")
        Archivo.Close()
        logs.Text = "Archivo de configuracion creado" & vbCrLf & logs.Text
    End Function
End Class