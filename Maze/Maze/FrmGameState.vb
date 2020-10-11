Public Class FrmGameState
    'Programmed By Syedur Rahman
    'Scary Maze Game
    '10/10/17

    '-----------------------------------------------------------------------------------------------------

    Dim PRight As Boolean
    Dim PLeft As Boolean
    Dim PUp As Boolean      'These variables allow the user to interact with their keyboard in level 3
    Dim PDown As Boolean

    Dim PRight2 As Boolean
    Dim PLeft2 As Boolean
    Dim PUp2 As Boolean     'These variables allow the user to interact with their keyboard in level 2
    Dim PDown2 As Boolean

    Dim PRight3 As Boolean
    Dim PLeft3 As Boolean
    Dim PUp3 As Boolean     'These variables allow the user to interact with their keyboard in level 1
    Dim PDown3 As Boolean

    Private Sub FrmGameState_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'This loading sub procedure makes the main menu, game title and the buttons appear
        'on the screen
        lblMadeBySyedur.Show()
        lblMadeBySyedur.Location = New Point(245, 510)
        lblMadeBySyedur.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Select()
    End Sub

#Region "Game Countdown Timer"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        'This timer allows the game timer to start from 60, and decrease by 1 second
        GameTimer.Start()
        GameTimer.Interval = 500
        If lblSecs.Text = 10 Then
            lblMins.ForeColor = Color.Gold
            lblColon.ForeColor = Color.Gold   'If the timer is less than 10 seconds, the colour of the label changes
            lblSecs.ForeColor = Color.Gold
            lblSecs.Text = Val(lblSecs.Text) - 1
        ElseIf lblSecs.Text = 0 Then
            lblMins.ForeColor = Color.Gold
            lblColon.ForeColor = Color.Gold
            lblSecs.ForeColor = Color.Gold    'If the timer reaches 0, the timer stops and a message box appears
            GameTimer.Stop()
            lblBall3.Hide()
            lblBall2.Hide()
            lblBall.Hide()
            Dim ex As DialogResult
            ex = MessageBox.Show("You have exceeded the time limit!", "Gameover", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            GameOverTimer.Enabled = True
            GameOverTimer.Start()
        Else
            lblSecs.Text = Val(lblSecs.Text) - 1  'This allows the label value to decrease by 1 second
        End If
    End Sub
#End Region

#Region "Game Over"
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles GameOverTimer.Tick
        'This block of code allows the gameover panel to appear on the screen when the user
        'has lost the game
        GameOverTimer.Stop()
        picPause.Hide()
        Label71.Hide()
        Label183.Hide()
        lblSecs.Hide()
        lblColon.Hide()
        lblMins.Hide()
        Panel3.Hide()
        Panel2.Hide()
        Panel1.Hide()
        Panel4.BringToFront()
        Panel4.Show()
        Label183.Text = "Level: 1"
    End Sub
#End Region

#Region "Pausing and Resuming the game"
    Private Sub picPause_Click(sender As Object, e As EventArgs) Handles picPause.Click
        'This block of code stops the game timer and ball from moving when the 
        'user has clicked the pause button
        GameTimer.Stop()
        lblBall3.Hide()
        lblBall2.Hide()
        lblBall.Hide()
        lblPause.BringToFront()
        lblPause.Show()
    End Sub

    Private Sub picPause_DoubleClick(sender As Object, e As EventArgs) Handles picPause.DoubleClick
        'This block of code resumes the game timer and allows the ball to move again when
        'the user has double clicked the pause button
        GameTimer.Start()
        lblBall3.Show()
        lblBall2.Show()
        lblBall.Show()
        lblPause.Hide()
    End Sub
#End Region

#Region "Moving the ball - Key Down/Up event and Tick event"
    Private Sub MoveballLandR(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Right Then
            PRight = True
        ElseIf e.KeyValue = Keys.Left Then
            PLeft = True
        ElseIf e.KeyValue = Keys.Up Then
            PUp = True
        ElseIf e.KeyValue = Keys.Down Then
            PDown = True
        End If
        If e.KeyValue = Keys.Right Then
            PRight2 = True
        ElseIf e.KeyValue = Keys.Left Then    'This line of code allows the ball to move when the user presses
            'down on the keyboard
            PLeft2 = True
        ElseIf e.KeyValue = Keys.Up Then
            PUp2 = True
        ElseIf e.KeyValue = Keys.Down Then
            PDown2 = True
        End If
        If e.KeyValue = Keys.Right Then
            PRight3 = True
        ElseIf e.KeyValue = Keys.Left Then
            PLeft3 = True
        ElseIf e.KeyValue = Keys.Up Then
            PUp3 = True
        ElseIf e.KeyValue = Keys.Down Then
            PDown3 = True
        End If
    End Sub

    Private Sub MoveballStop(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.Right Then
            PRight = False
        ElseIf e.KeyValue = Keys.Left Then
            PLeft = False
        ElseIf e.KeyValue = Keys.Up Then
            PUp = False
        ElseIf e.KeyValue = Keys.Down Then
            PDown = False
        End If
        If e.KeyValue = Keys.Right Then
            PRight2 = False
        ElseIf e.KeyValue = Keys.Left Then 'This line of code stops the ball from moving when the user lifts
            'up the key button on the keyboard
            PLeft2 = False
        ElseIf e.KeyValue = Keys.Up Then
            PUp2 = False
        ElseIf e.KeyValue = Keys.Down Then
            PDown2 = False
        End If
        If e.KeyValue = Keys.Right Then
            PRight3 = False
        ElseIf e.KeyValue = Keys.Left Then
            PLeft3 = False
        ElseIf e.KeyValue = Keys.Up Then
            PUp3 = False
        ElseIf e.KeyValue = Keys.Down Then
            PDown3 = False
        End If

        If lblBall3.Bounds.IntersectsWith(FinishLevel1.Bounds) Then
            GameTimer.Stop()
            Panel2.BringToFront()
            Panel2.Show()
            lblBall2.Top = 10
            lblBall2.Left = 10
            Label183.Text = "Level: 2"  'If the user collides with the 'Finish' box in level 1, the current panel hides
            'and the panel for level 2 appears - they are taken to the next level
            lblMins.ForeColor = Color.Red
            lblColon.ForeColor = Color.Red
            lblSecs.ForeColor = Color.Red
            lblSecs.Text = 60
            GameTimer.Start()
        ElseIf lblBall2.Bounds.IntersectsWith(Finish1.Bounds) Then
            GameTimer.Stop()
            Panel3.BringToFront()
            Panel3.Show()
            lblBall.Top = 10
            lblBall.Left = 10
            Label183.Text = "Level: 3"  'If the user collides with the 'Finish' box in level 2, the current panel hides
            'and the panel for level 3 appears - they are taken to the next level
            lblMins.ForeColor = Color.Red
            lblColon.ForeColor = Color.Red
            lblSecs.ForeColor = Color.Red
            lblSecs.Text = 60
            GameTimer.Start()
        ElseIf lblBall.Bounds.IntersectsWith(Finish.Bounds) Then
            GameTimer.Stop()
            Panel3.Hide()
            Panel2.Hide()
            Panel1.Hide()
            picPause.Hide() 'If the user collides with the 'Finish' box in level 3, the current panel hides
            'and the scary face appears on the screen
            Label71.Hide()
            Label183.Hide()
            lblSecs.Hide()   'This code hides the game countdown label
            lblColon.Hide()
            lblMins.Hide()

            ScaryFaceTimer.Enabled = True
            ScaryFaceTimer.Start()
            My.Computer.Audio.Play(My.Resources.SOUND, AudioPlayMode.BackgroundLoop) 'This line of code allows 
            'the computer to play the scary sound in a loop
        End If
    End Sub

    Private Sub MoveBall_Tick(sender As Object, e As EventArgs) Handles MoveBall.Tick
        If PRight = True Then
            lblBall.Left = lblBall.Left + 2
        ElseIf PLeft = True Then
            lblBall.Left = lblBall.Left - 2
        ElseIf PUp = True Then                 'These conditions allows the user to interact with their keyboard in level 3
            lblBall.Top = lblBall.Top - 2
        ElseIf PDown = True Then
            lblBall.Top = lblBall.Top + 2
        End If
        If PRight2 = True Then
            lblBall2.Left = lblBall2.Left + 3
        ElseIf PLeft2 = True Then
            lblBall2.Left = lblBall2.Left - 3
        ElseIf PUp2 = True Then                 'These conditions allows the user to interact with their keyboard in level 2
            lblBall2.Top = lblBall2.Top - 3
        ElseIf PDown2 = True Then
            lblBall2.Top = lblBall2.Top + 3
        End If
        If PRight3 = True Then
            lblBall3.Left = lblBall3.Left + 3
        ElseIf PLeft3 = True Then
            lblBall3.Left = lblBall3.Left - 3
        ElseIf PUp3 = True Then                 'These conditions allows the user to interact with their keyboard in level 1
            lblBall3.Top = lblBall3.Top - 3
        ElseIf PDown3 = True Then
            lblBall3.Top = lblBall3.Top + 3
        End If
#End Region

#Region "Level 3"
        'These conditions prevents
        'the ball from interacting with the walls. When the user hits the walls, it goes back to the
        'coordinate (10,10) - the top of the form
        If lblBall.Bounds.IntersectsWith(Label1.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label2.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label3.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label4.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label5.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label6.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label7.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label8.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label9.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label10.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label11.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label12.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label13.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label14.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label15.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label16.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label17.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label18.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label19.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label20.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label21.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label22.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label23.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label24.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label25.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label26.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label27.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label28.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label29.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label30.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label31.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label32.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label33.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label34.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label35.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label36.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label37.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label38.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label39.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label40.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label41.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label42.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label43.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label44.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label45.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label46.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label47.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label48.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label49.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label50.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label51.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label52.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label53.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label54.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label55.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label56.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label57.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label58.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label59.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label60.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label61.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label62.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label63.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label64.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label65.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label66.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label67.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label68.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label69.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label70.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label71.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label215.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label214.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label216.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
        If lblBall.Bounds.IntersectsWith(Label217.Bounds) Then
            lblBall.Top = 10
            lblBall.Left = 10
        End If
#End Region   'Collision detection for level 3

#Region "Level 2"
        'These conditions prevents
        'the ball from interacting with the walls. When the user hits the walls, it goes back to the
        'coordinate (10,10) - the top of the form
        If lblBall2.Bounds.IntersectsWith(Label74.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label142.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label148.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label87.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label89.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label91.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label95.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label93.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label99.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label98.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label100.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label103.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label104.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label105.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label106.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label107.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label109.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label112.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label108.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label113.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label114.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label115.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label116.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label117.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label118.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label119.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label120.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label121.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label122.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label138.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label125.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label126.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label139.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label129.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label131.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label133.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label135.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label124.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label209.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label211.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label212.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
        If lblBall2.Bounds.IntersectsWith(Label213.Bounds) Then
            lblBall2.Top = 10
            lblBall2.Left = 10
        End If
#End Region   'Collision detection for level 2

#Region "Level 1"
        'These conditions prevents
        'the ball from interacting with the walls. When the user hits the walls, it goes back to the
        'coordinate (10,10) - the top of the form
        If lblBall3.Bounds.IntersectsWith(Label188.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label190.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label200.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label199.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label198.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label197.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label196.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label195.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label194.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label193.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label192.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label191.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label167.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label175.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label177.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label176.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label171.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label174.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label172.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label169.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label168.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label182.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label181.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label186.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label184.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label208.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label178.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label185.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label202.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label203.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label207.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label206.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label205.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
        If lblBall3.Bounds.IntersectsWith(Label204.Bounds) Then
            lblBall3.Top = 10
            lblBall3.Left = 10
        End If
    End Sub
#End Region   'Collision detection for level 1

#Region "Quit Button"
    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me.Close() 'This code exits the application
    End Sub
#End Region

#Region "Start Button"
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        lblMadeBySyedur.Hide()
        btnStart.Hide()
        btnQuit.Hide()
        lblTitle.Hide()
        Panel1.BringToFront()
        Panel1.Show()             'This sub procedure hides all the content in the main menu
        'and allows the game to start, when the user has clicked "Start"
        picPause.Show()
        Label71.Show()
        Label183.Show()
        lblSecs.Show()
        lblColon.Show()
        lblMins.Show()
        If GameTimer.Enabled = True Then
            GameTimer.Start()              'This code allows the game timer to start, when the user has
            'clicked start
        Else lblSecs.Text = 60
            GameTimer.Start()
        End If

    End Sub
#End Region

#Region "Back Home Button (When the player has lost)"
    Private Sub lblBackHome_Click(sender As Object, e As EventArgs) Handles lblBackHome.Click
        'This sub procedure takes the user back to the main menu when the user has clicked the 'Back Home' button
        Panel4.Hide()
        btnStart.Show()
        lblMadeBySyedur.Show()
        btnQuit.Show()
        lblTitle.Show()
        lblMins.ForeColor = Color.Red
        lblColon.ForeColor = Color.Red
        lblSecs.ForeColor = Color.Red
        lblSecs.Text = 60
        If lblSecs.Text = 10 Then
            lblMins.ForeColor = Color.Gold
            lblColon.ForeColor = Color.Gold
            lblSecs.ForeColor = Color.Gold
            lblSecs.Text = Val(lblSecs.Text) - 1
        End If

        lblBall3.BringToFront()
        lblBall3.Show()
        lblBall3.Top = 10
        lblBall3.Left = 10
        lblBall2.Show()
        lblBall2.Top = 10
        lblBall2.Left = 10
        lblBall.Show()
        lblBall.Top = 10
        lblBall.Left = 10
        GameTimer.Start()

        If lblBall3.Bounds.IntersectsWith(FinishLevel1.Bounds) Then
            GameTimer.Stop()
            Panel2.BringToFront()
            Panel2.Show()
            lblBall2.Top = 10
            lblBall2.Left = 10
            Label183.Text = "Level: 2"
            lblMins.ForeColor = Color.Red
            lblColon.ForeColor = Color.Red
            lblSecs.ForeColor = Color.Red
            lblSecs.Text = 60
            GameTimer.Start()
        ElseIf lblBall2.Bounds.IntersectsWith(Finish1.Bounds) Then
            GameTimer.Stop()
            Panel3.BringToFront()
            Panel3.Show()
            lblBall.Top = 10
            lblBall.Left = 10
            Label183.Text = "Level: 3"
            lblMins.ForeColor = Color.Red
            lblColon.ForeColor = Color.Red
            lblSecs.ForeColor = Color.Red
            lblSecs.Text = 60
            GameTimer.Start()
        ElseIf lblBall.Bounds.IntersectsWith(Finish.Bounds) Then
            GameTimer.Stop()
            Panel3.Hide()
            Panel2.Hide()
            Panel1.Hide()
            picPause.Hide()
            Label71.Hide()
            Label183.Hide()
            lblSecs.Hide()
            lblColon.Hide()
            lblMins.Hide()

            ScaryFaceTimer.Enabled = True
            ScaryFaceTimer.Start()
            My.Computer.Audio.Play(My.Resources.SOUND, AudioPlayMode.BackgroundLoop) 'This line of code allows 
            'the computer to play the scary sound
        End If
    End Sub
#End Region

#Region "Play Again Button"
    Private Sub lblPlayAgain_Click(sender As Object, e As EventArgs) Handles lblPlayAgain.Click
        'This allows the whole game to restart when the user has clicked the play again button
        'Repeated code
        Panel4.Hide()
        Panel1.BringToFront()
        Panel1.Show()
        picPause.Show()
        Label71.Show()
        Label183.Show()
        lblSecs.Show()
        lblColon.Show()
        lblMins.Show()

        lblMins.ForeColor = Color.Red
        lblColon.ForeColor = Color.Red
        lblSecs.ForeColor = Color.Red
        lblSecs.Text = 60
        If lblSecs.Text = 10 Then
            lblMins.ForeColor = Color.Gold
            lblColon.ForeColor = Color.Gold
            lblSecs.ForeColor = Color.Gold
            lblSecs.Text = Val(lblSecs.Text) - 1
        End If
        lblBall3.BringToFront()
        lblBall3.Show()
        lblBall3.Top = 10
        lblBall3.Left = 10
        lblBall2.Show()
        lblBall2.Top = 10
        lblBall2.Left = 10
        lblBall.Show()
        lblBall.Top = 10
        lblBall.Left = 10
        GameTimer.Start()

        If lblBall3.Bounds.IntersectsWith(FinishLevel1.Bounds) Then
            GameTimer.Stop()
            Panel2.BringToFront()
            Panel2.Show()
            lblBall2.Top = 10
            lblBall2.Left = 10
            Label183.Text = "Level: 2"
            lblMins.ForeColor = Color.Red
            lblColon.ForeColor = Color.Red
            lblSecs.ForeColor = Color.Red
            lblSecs.Text = 60
            GameTimer.Start()
        ElseIf lblBall2.Bounds.IntersectsWith(Finish1.Bounds) Then
            GameTimer.Stop()
            Panel3.BringToFront()
            Panel3.Show()
            lblBall.Top = 10
            lblBall.Left = 10
            Label183.Text = "Level: 3"
            lblMins.ForeColor = Color.Red
            lblColon.ForeColor = Color.Red
            lblSecs.ForeColor = Color.Red
            lblSecs.Text = 60
            GameTimer.Start()
        ElseIf lblBall.Bounds.IntersectsWith(Finish.Bounds) Then
            GameTimer.Stop()
            Panel3.Hide()
            Panel2.Hide()
            Panel1.Hide()
            picPause.Hide()
            Label71.Hide()
            Label183.Hide()
            lblSecs.Hide()
            lblColon.Hide()
            lblMins.Hide()

            ScaryFaceTimer.Enabled = True
            ScaryFaceTimer.Start()
            My.Computer.Audio.Play(My.Resources.SOUND, AudioPlayMode.BackgroundLoop)
        End If
    End Sub
#End Region

#Region "Scary face appearance"
    Private Sub ScaryFaceTimer_Tick(sender As Object, e As EventArgs) Handles ScaryFaceTimer.Tick
        ScaryFaceTimer.Stop()
        picScaryFace.BringToFront()
        picScaryFace.Show()         'This timer allows the scary to appear on the screen
        YouWonTimer.Enabled = True
        YouWonTimer.Start()
    End Sub
#End Region

#Region "Game won message box"
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles YouWonTimer.Tick
        YouWonTimer.Stop()
        My.Computer.Audio.Stop()
        Dim ex As DialogResult
        ex = MessageBox.Show("LOOOL! :)", "YOU WIN!", MessageBoxButtons.OK) 'When the player has won the game
        'and seen the scary face, the timer will stop and a message box will appear saying "LOL"
        Me.Close()
    End Sub
#End Region

End Class
