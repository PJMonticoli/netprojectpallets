Imports Guna.UI2.WinForms
Imports MaterialSkin.Controls

Module ModuloControles

#Region "CONTROLES CARGA MOVIMIENTO PALLETS"
    Public Sub LimpiarCamposMovPallets(ByRef controles As IEnumerable(Of Control))
        For Each ctrl As Control In controles
            Select Case True
                Case TypeOf ctrl Is Guna2ComboBox
                    CType(ctrl, Guna2ComboBox).SelectedIndex = -1
                Case TypeOf ctrl Is MaterialComboBox
                    CType(ctrl, MaterialComboBox).SelectedIndex = -1
                Case TypeOf ctrl Is MaterialTextBox
                    CType(ctrl, MaterialTextBox).Clear()
                Case TypeOf ctrl Is Guna2TextBox
                    CType(ctrl, Guna2TextBox).Clear()
                Case TypeOf ctrl Is Guna2DataGridView
                    CType(ctrl, Guna2DataGridView).Rows.Clear()
                Case TypeOf ctrl Is MaterialRadioButton
                    CType(ctrl, MaterialRadioButton).Checked = False
                    CType(ctrl, MaterialRadioButton).Checked = True
                Case TypeOf ctrl Is MaterialSwitch
                    CType(ctrl, MaterialSwitch).Checked = True
            End Select
        Next
    End Sub

#End Region

#Region "Controles Pallets Por Cliente"
    Public Sub LimpiarControles(ByRef controles As IEnumerable(Of Control))
        For Each ctrl As Control In controles
            Select Case True
                Case TypeOf ctrl Is MaterialTextBox
                    CType(ctrl, MaterialTextBox).Clear()
                Case TypeOf ctrl Is MaterialTextBox2
                    CType(ctrl, MaterialTextBox2).Clear()
                Case TypeOf ctrl Is Guna2TextBox
                    CType(ctrl, Guna2TextBox).Clear()
                Case TypeOf ctrl Is Guna2DataGridView
                    CType(ctrl, Guna2DataGridView).Visible = False
                Case TypeOf ctrl Is Label
                    CType(ctrl, Label).Visible = False
                Case TypeOf ctrl Is Guna2GroupBox
                    CType(ctrl, Guna2GroupBox).Visible = False
            End Select
        Next
    End Sub
#End Region

#Region "Controles Devoluciones"
    Public Sub LimpiarControlesDevCliente(ByRef controles As IEnumerable(Of Control))
        For Each ctrl As Control In controles
            Select Case True
                Case TypeOf ctrl Is MaterialTextBox
                    CType(ctrl, MaterialTextBox).Clear()
                Case TypeOf ctrl Is Guna2ComboBox
                    CType(ctrl, Guna2ComboBox).SelectedIndex = -1
                Case TypeOf ctrl Is Guna2DataGridView
                    CType(ctrl, Guna2DataGridView).Rows.Clear()
                Case TypeOf ctrl Is Guna2TextBox
                    CType(ctrl, Guna2TextBox).Clear()
            End Select
        Next
    End Sub



    Public Sub LimpiarControlesCargaDev(ByRef controles As IEnumerable(Of Control))
        For Each ctrl As Control In controles
            Select Case True
                Case TypeOf ctrl Is MaterialTextBox
                    CType(ctrl, MaterialTextBox).Clear()
                Case TypeOf ctrl Is Guna2ComboBox
                    CType(ctrl, Guna2ComboBox).SelectedIndex = -1
            End Select
        Next
    End Sub
#End Region


#Region "Controles Específicos para Limpiar"
    Public Sub LimpiarSeleccion(ByRef controles As IEnumerable(Of Control), ByVal dgv As DataGridView)
        For Each ctrl As Control In controles
            Select Case True
                Case TypeOf ctrl Is Guna2ComboBox
                    CType(ctrl, Guna2ComboBox).SelectedIndex = -1
                Case TypeOf ctrl Is MaterialRadioButton
                    CType(ctrl, MaterialRadioButton).Checked = False
                Case TypeOf ctrl Is MaterialSwitch
                    CType(ctrl, MaterialSwitch).Checked = True
            End Select
        Next

        ' Cargar datos iniciales en la grilla
        Dim controllerReportes As New ControllerReportes()
        Dim dgvLoaderReporte As New DataGridLoader(dgv)
        dgvLoaderReporte.CargarDatosEnGrillaReporteInicial(controllerReportes)
    End Sub



    Public Sub LimpiarSeleccionInforme(ByRef controles As IEnumerable(Of Control), ByVal dgv As DataGridView)
        For Each ctrl As Control In controles
            Select Case True
                Case TypeOf ctrl Is Guna2ComboBox
                    CType(ctrl, Guna2ComboBox).SelectedIndex = -1
                Case TypeOf ctrl Is MaterialRadioButton
                    CType(ctrl, MaterialRadioButton).Checked = False
                Case TypeOf ctrl Is MaterialSwitch
                    CType(ctrl, MaterialSwitch).Checked = True
            End Select
        Next

        ' Cargar datos iniciales en la grilla
        Dim controllerInforme As New ControllerInformes()
        Dim dgvLoaderInforme As New DataGridLoader(dgv)
        dgvLoaderInforme.CargarDatosEnGrillaInformeSaldosInicial(controllerInforme)
    End Sub
#End Region
End Module
