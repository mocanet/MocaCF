Imports System.Drawing

Namespace Win


    Public Class HsvColor

        Private _h As Single
        ''' <summary>
        ''' 色相 (Hue)
        ''' </summary>
        Public ReadOnly Property H() As Single
            Get
                Return Me._h
            End Get
        End Property

        Private _s As Single
        ''' <summary>
        ''' 彩度 (Saturation)
        ''' </summary>
        Public ReadOnly Property S() As Single
            Get
                Return Me._s
            End Get
        End Property

        Private _v As Single
        ''' <summary>
        ''' 明度 (Value, Brightness)
        ''' </summary>
        Public ReadOnly Property V() As Single
            Get
                Return Me._v
            End Get
        End Property

        Private Sub New(ByVal hue As Single, _
                        ByVal saturation As Single, _
                        ByVal brightness As Single)
            If hue < 0.0F OrElse 360.0F <= hue Then
                Throw New ArgumentException("hueは0以上360未満の値です。", "hue")
            End If
            If saturation < 0.0F OrElse 1.0F < saturation Then
                Throw New ArgumentException("saturationは0以上1以下の値です。", "saturation")
            End If
            If brightness < 0.0F OrElse 1.0F < brightness Then
                'brightness = IIf(1.0F < brightness, 1, 0)
                Throw New ArgumentException("brightnessは0以上1以下の値です。", "brightness")
            End If

            Me._h = hue
            Me._s = saturation
            Me._v = brightness
        End Sub

        ''' <summary>
        ''' 指定したColorからHsvColorを作成する
        ''' </summary>
        ''' <param name="rgb">Color</param>
        ''' <returns>HsvColor</returns>
        Public Shared Function FromRgb(ByVal rgb As Color) As HsvColor
            Dim r As Single = CSng(rgb.R) / 255.0F
            Dim g As Single = CSng(rgb.G) / 255.0F
            Dim b As Single = CSng(rgb.B) / 255.0F

            Dim max As Single = Math.Max(r, Math.Max(g, b))
            Dim min As Single = Math.Min(r, Math.Min(g, b))

            Dim brightness As Single = max

            Dim hue As Single, saturation As Single
            If max = min Then
                'undefined
                hue = 0.0F
                saturation = 0.0F
            Else
                Dim c As Single = max - min

                If max = r Then
                    hue = (g - b) / c
                ElseIf max = g Then
                    hue = (b - r) / c + 2.0F
                Else
                    hue = (r - g) / c + 4.0F
                End If
                hue *= 60.0F
                If hue < 0.0F Then
                    hue += 360.0F
                End If

                saturation = c / max
            End If

            Return New HsvColor(hue, saturation, brightness)
        End Function

        Public Shared Function ToRgb(ByVal hue As Single, _
                        ByVal saturation As Single, _
                        ByVal brightness As Single) As Color
            Return ToRgb(New HsvColor(hue, saturation, brightness))
        End Function

        ''' <summary>
        ''' 指定したHsvColorからColorを作成する
        ''' </summary>
        ''' <param name="hsv">HsvColor</param>
        ''' <returns>Color</returns>
        Public Shared Function ToRgb(ByVal hsv As HsvColor) As Color
            Dim v As Single = hsv.V
            Dim s As Single = hsv.S

            Dim r As Single, g As Single, b As Single
            If s = 0 Then
                r = v
                g = v
                b = v
            Else
                Dim h As Single = hsv.H / 60.0F
                Dim i As Integer = CInt(Math.Floor(h))
                Dim f As Single = h - i
                Dim p As Single = v * (1.0F - s)
                Dim q As Single
                If i Mod 2 = 0 Then
                    't
                    q = v * (1.0F - (1.0F - f) * s)
                Else
                    q = v * (1.0F - f * s)
                End If

                Select Case i
                    Case 0
                        r = v
                        g = q
                        b = p
                        Exit Select
                    Case 1
                        r = q
                        g = v
                        b = p
                        Exit Select
                    Case 2
                        r = p
                        g = v
                        b = q
                        Exit Select
                    Case 3
                        r = p
                        g = q
                        b = v
                        Exit Select
                    Case 4
                        r = q
                        g = p
                        b = v
                        Exit Select
                    Case 5
                        r = v
                        g = p
                        b = q
                        Exit Select
                    Case Else
                        Throw New ArgumentException("色相の値が不正です。", "hsv")
                End Select
            End If

            Return Color.FromArgb(CInt(Math.Round(r * 255.0F)), _
                                  CInt(Math.Round(g * 255.0F)), _
                                  CInt(Math.Round(b * 255.0F)))
        End Function

    End Class

End Namespace
