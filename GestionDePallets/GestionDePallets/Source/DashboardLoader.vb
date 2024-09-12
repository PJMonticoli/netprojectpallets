Imports System.Windows.Forms.Integration
Imports LiveCharts
Imports LiveCharts.Wpf
Imports MaterialSkin.Controls


Public Class DashboardLoader
    Private ReadOnly controller As ControllerPallets

    Public Sub New(controller As ControllerPallets)
        Me.controller = controller
    End Sub


    Public Sub LoadBarChart(barChart As LiveCharts.WinForms.CartesianChart)
        Dim seriesCollection As SeriesCollection = controller.CargarGraficoBarras()

        barChart.Series = seriesCollection


        barChart.AxisY.Clear()
        barChart.AxisY.Add(New Axis() With {
            .Title = "Cantidad",
            .LabelFormatter = Function(value) value.ToString("N0")
        })


        barChart.AxisX.Clear()
        Dim labels As New List(Of String)


        If seriesCollection.Count > 0 Then
            Dim values = seriesCollection.First().Values
            For Each item In values
                Dim chartPoint = TryCast(item, ChartPoint)
            Next
        End If

        barChart.AxisX.Add(New Axis() With {
            .Title = "Clientes",
            .Labels = labels
        })

        barChart.LegendLocation = LegendLocation.Right
    End Sub

    Public Sub LoadLineChart(lineChart As LiveCharts.WinForms.CartesianChart)
        Dim seriesCollection As SeriesCollection = controller.CargarGraficoLineasEstado()
        lineChart.AxisY.Add(New Axis() With {
            .Title = "Cantidades"
        })
        lineChart.AxisX.Add(New Axis() With {
            .Labels = New String() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
        })

        lineChart.Series = seriesCollection
    End Sub
    Public Sub LoadKPICantidades(lblCantIngreso As Label, lblCantEgreso As Label)
        Dim resultadoCantidades = controller.ObtenerCantidadPalletsMesActual()
        lblCantIngreso.Text = resultadoCantidades.sumaIngreso.ToString()
        lblCantEgreso.Text = resultadoCantidades.sumaEgreso.ToString()
    End Sub



    Public Sub LoadKPIRetornos(lblCantRetorno As Label, lblCantSinRetorno As Label)
        Dim resultadoRetornados = controller.ObtenerCantidadRetornadosMesActual()
        Dim resultadoNoRetornados = controller.ObtenerCantidadNoRetornadosMesActual()
        lblCantRetorno.Text = resultadoRetornados
        lblCantSinRetorno.Text = resultadoNoRetornados
    End Sub

    Public Sub LoadKPIEstados(lblCantBuenEstado As Label, lblCantMalEstado As Label, cantBuenEstado As MaterialProgressBar, cantMalEstado As MaterialProgressBar, lblPorcBuenEstado As Label, lblPorcMalEstado As Label)
        Dim resultadoEstados = controller.ObtenerEstadoPalletsMesActual()

        ' Calcular el total
        Dim totalPallets As Integer = resultadoEstados.SumaBuenEstado + resultadoEstados.SumaMalEstado

        ' Calcular los porcentajes
        Dim porcentajeBuenEstado As Integer = 0
        Dim porcentajeMalEstado As Integer = 0

        If totalPallets > 0 Then
            porcentajeBuenEstado = (resultadoEstados.SumaBuenEstado * 100) / totalPallets
            porcentajeMalEstado = (resultadoEstados.SumaMalEstado * 100) / totalPallets
        End If

        ' Asignar los valores a los MaterialProgressBar
        lblCantBuenEstado.Text = resultadoEstados.SumaBuenEstado
        lblCantMalEstado.Text = resultadoEstados.SumaMalEstado
        cantBuenEstado.Value = porcentajeBuenEstado
        cantMalEstado.Value = porcentajeMalEstado

        'Label's % dashboard
        lblPorcBuenEstado.Text = porcentajeBuenEstado & " % sobre el total"
        lblPorcMalEstado.Text = porcentajeMalEstado & " % sobre el total"
    End Sub





End Class
