'Tratto da Manuale Farri-Piotti-Sbroggiò pag. 704 Esercizio 100
Imports System.Configuration
Imports System.Threading
Public Class Form1
    Dim ImmagineOrologio As Bitmap = My.Resources.Quadrante_Orologio_20
    Dim Ore As Integer
    Dim Minuti As Integer
    Dim Secondi As Integer
    Dim Centesimi As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Timer1.Enabled = False
        Timer1.Interval = 10     'in millisecondi con 1000 = 1 secondo, 100 decimi di secondo, 10 centesimi di secondo
        Ore = 0
        Minuti = 0
        Secondi = 0
        Centesimi = 0
        Label1.Text = Secondi
        Label2.Text = Centesimi
        Label5.Text = Minuti
        Label6.Text = Ore
        If Timer1.Enabled = False Then
            Button3.Enabled = False
            Button2.Enabled = False
            Button1.Enabled = True
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Centesimi += 1
        If Centesimi = "100" Then
            Centesimi = 0
            Secondi += 1
        End If
        If Secondi = "60" Then
            Secondi = 0
            Minuti += 1
        End If
        If Minuti = "60" Then
            Minuti = 0
            Ore += 1
        End If
        If Ore = "24" Then
            Ore = 0
        End If
        Me.Invalidate()
        Label1.Text = Centesimi
        Label2.Text = Secondi
        Label5.Text = Minuti
        Label6.Text = Ore
    End Sub
    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim Tempo As Integer
        Dim PuntoCentrale As New Point(Me.ClientRectangle.Width / 2, Me.ClientRectangle.Height / 2)
        Tempo = Secondi
        Secondi = (Tempo * 6) + 270
        Dim ColoreSfondo As Color = Color.White
        Dim PennaSecondi As New Pen(Color.Red, 1)
        e.Graphics.DrawPie(PennaSecondi, PuntoCentrale.X - 130, PuntoCentrale.Y - 130, 260, 260, Secondi, 360)
        Dim CancellaSecondi As New Pen(ColoreSfondo, 3)
        e.Graphics.DrawEllipse(CancellaSecondi, PuntoCentrale.X - 130, PuntoCentrale.Y - 130, 260, 260)
        e.Graphics.FillEllipse(Brushes.Black, PuntoCentrale.X - 10, PuntoCentrale.Y - 10, 20, 20)
        e.Graphics.FillEllipse(Brushes.Red, PuntoCentrale.X - 4, PuntoCentrale.Y - 4, 8, 8)
        Secondi = Tempo
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        Timer1.Start()
        If Timer1.Enabled = True Then
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Timer1.Stop()
        If Timer1.Enabled = False Then
            Button3.Enabled = True
            Button2.Enabled = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Enabled = False
        Timer1.Stop()
        Ore = 0
        Minuti = 0
        Secondi = 0
        Centesimi = 0
        Label1.Text = Secondi
        Label2.Text = Centesimi
        Label5.Text = Minuti
        Label6.Text = Ore
        Me.Invalidate()
        If Timer1.Enabled = False Then
            Button3.Enabled = False
            Button2.Enabled = False
            Button1.Enabled = True
        End If
    End Sub
End Class

