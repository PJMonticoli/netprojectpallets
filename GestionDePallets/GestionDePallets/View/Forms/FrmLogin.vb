Imports System.Globalization
Imports System.Threading


Public Class FrmLogin
    Public obj As New ModeloUsuario
    Dim Datos As New ControlerLogin
    Public id As String
    Public Property Variablesglobales As Object

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Dim newCulture As CultureInfo = New CultureInfo("es-ES")
        Thread.CurrentThread.CurrentCulture = newCulture
        Thread.CurrentThread.CurrentUICulture = newCulture
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lblestado.Text = "Gestión de Pallets"
        Lblestado.ForeColor = Color.FromArgb(255, 255, 255)
        Lblestado.Font = New Font(Lblestado.Font, FontStyle.Bold)
        ' Centrar el Label horizontalmente en el formulario
        Lblestado.Left = (Pnlestado.Width - Lblestado.Width) / 2
        ' Verificar si se proporcionan al menos dos parámetros
        Dim peticion As String
        If Environment.GetCommandLineArgs.Length > 1 Then
            If Command().Length >= 2 Then
                ' Obtener el primer y segundo parámetro
                id = Environment.GetCommandLineArgs(1)
                peticion = Environment.GetCommandLineArgs(2)

                ' Realizar la validación para decidir si se debe realizar una solicitud GET o PUT
                Me.WindowState = FormWindowState.Minimized
                Me.ShowInTaskbar = False
                ' Llamar al método para la solicitud GET
                Dim frmPrincipal As New FrmPrincipal()
                frmPrincipal.Show()

            End If

        Else
            If My.Computer.Name = "SISTEMAS3" Then
                txtUsername.Text = "jorgedc"
                txtPassword.Text = "cabreraj"
            End If
            If Version() = False Then
                MsgBox("No se puede abrir el programa porque posee una versión desactualizada. Contactese con sistemas", vbOKOnly + vbObjectError, "Version Desactualizada")
                End
            End If
        End If
    End Sub
    Private Sub CorroborarDatos()
        Dim errores As String = ValidarCampos()
        If errores <> "" Then
            Autorización("NO")
            MessageBox.Show("Se encontraron los siguientes errores: " & errores, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Autorización("BLOQUEADO")
            Exit Sub
        End If


        Select Case Datos.ValidarPermisos(220, txtUsername.Text, txtPassword.Text, obj)
            Case 1 'Sí se poseen permisos
                obj.User = txtUsername.Text
                '  Variablesglobales.idusuario = obj.CodUser
                Autorización("SI")
            Case 0 'No se poseen permisos
                Autorización("NO")
                MsgBox("Se ha detectado que el usuario ingresado no posee permisos para la aplicación, comuníquese con el departamento de sistemas.", vbCritical, "Inicio de sesión")
                Autorización("BLOQUEADO")
                Me.txtUsername.Focus()

            Case -1 'Error al buscar datos
                Autorización("NO")
                MsgBox("Se ha producido un error al buscar datos, comuníquese con el departamento de sistemas.", vbCritical, "Inicio de sesión")
                Me.txtUsername.Focus()
                Autorización("BLOQUEADO")

            Case -2 '-2 Usuario no existente
                Autorización("NO")
                MsgBox("No se ha encontrado el usuario ingresado, verifique los datos e intente nuevamente.", vbInformation, "Inicio de sesión")
                Me.txtUsername.Focus()
                Autorización("BLOQUEADO")

            Case -3 'Usuario desactivado
                Autorización("NO")
                MsgBox("El usario ha sido desactivado en la gestión, comuníquese con el departamento de sistemas.", vbExclamation, "Inicio de sesión")
                Me.txtUsername.Focus()
                Autorización("BLOQUEADO")

            Case -4 'Clave no coincidente
                Autorización("NO")
                MsgBox("La contraseña no es válida, vuelva a intentarlo.", vbInformation, "Inicio de sesión")
                txtPassword.Focus()
                Autorización("BLOQUEADO")

            Case -5 'Host no autorizado
                Autorización("NO")
                MsgBox("Ud. no está autorizado a ejecutar la gestión en este equipo.", vbInformation, "Inicio de sesión")
                Me.txtUsername.Focus()
                Autorización("BLOQUEADO")

        End Select
    End Sub
    Private Sub Autorización(ByVal Estado As String)

        Select Case Estado
            Case "SI"
                Lblestado.Text = "Acceso Autorizado"
                Lblestado.ForeColor = Color.Green
                ' Pnlestado.BackColor = Color.Black
                Congelar(0.7)
                Me.Refresh()
                'obj.User = TxtUsuario.Text
                'Variablesglobales.idusuario = obj.CodUser
                Dim frm As New FrmPrincipal


                'Lo freno un segundo así se ve el mensaje de Acceso Autorizado


                Me.Visible = False
                frm.Show()

            Case "NO"
                ' Pnlestado.BackColor = Color.Black
                Lblestado.Text = "Acceso Denegado"
                Lblestado.ForeColor = Color.Red
                Me.Refresh()

            Case "BLOQUEADO"
                ' Pnlestado.BackColor = Color.Black
                Lblestado.Text = "Planificación de Recursos"
                Lblestado.ForeColor = Color.Black
                Me.Refresh()
        End Select
    End Sub
    Private Sub Congelar(ByVal Segundos As Integer)
        Dim Fin As Date = Now.AddSeconds(Segundos)
        Dim Ahora As Date

        While Ahora <= Fin
            Ahora = Now
        End While
    End Sub

    Private Function ValidarCampos() As String
        Try
            Dim errores As String = ""

            If Trim(txtUsername.Text) = "" Then errores = errores & vbCr & "- Nombre de usuario en blanco."
            If Trim(txtPassword.Text) = "" Then errores = errores & vbCr & "- Contraseña en blanco."

            Return errores
        Catch ex As Exception
            Return "Error en validación de datos."
        End Try
    End Function

    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPassword.Focus()
        End If
    End Sub


    Private Sub TxtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            CorroborarDatos()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Esta seguro que desea cancelar?", vbOKCancel + vbQuestion, "Salir del Sistema") = vbOK Then
            End
        Else
            txtPassword.Text = ""
            txtUsername.Text = ""
        End If
    End Sub

    Private Sub BtnIngresar_Click_1(sender As Object, e As EventArgs) Handles BtnIngresar.Click

        CorroborarDatos()
    End Sub

    Private Sub Btncerrar_Click(sender As Object, e As EventArgs) Handles Btncerrar.Click
        If MsgBox("Esta Seguro de Salir", vbOKCancel + vbQuestion, "Salir Sistema") = vbOK Then
            End
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Btnminizar_Click(sender As Object, e As EventArgs) Handles Btnminizar.Click
        If MsgBox("¿Esta seguro que desea salir?", vbOKCancel + vbQuestion, "Salir del Sistema") = vbOK Then
            End
        End If
    End Sub
    Public Function Version() As Boolean
        Try
            Datos.obtenerVersion()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function versionstring() As String
        Try
            Dim version
            version = Datos.obtenerVersion2()
            Return version
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub TxtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnIngresar.Focus()
        End If
    End Sub
End Class