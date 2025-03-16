Imports System

Module Program
    Dim usuarioValido As String = "Alfredo123"
    Dim pinValido As String = "1234"
    Dim saldo As Decimal = 500.0

    Sub Main()
        Dim intentos As Integer = 0
        Dim usuario As String
        Dim pin As String


        Do
            Console.Write("Ingrese su usuario: ")
            usuario = Console.ReadLine()

            Console.Write("Ingrese su pin: ")
            pin = Console.ReadLine()

            If usuario = usuarioValido And pin = pinValido Then
                Console.WriteLine("inicio de sesion exitoso")
                MenuPrincipal()
                Exit Do
            Else
                intentos += 1
                Console.WriteLine("Credenciales incorrecto. Intentos ´{0}/3", intentos)

            End If

            If intentos = 3 Then
                Console.WriteLine("Demasiados intentos fallidos. Cuenta bloqueada.")
                Exit Do
            End If
        Loop
    End Sub
    Sub MenuPrincipal()
        Dim opcion As Integer
        Do
            Console.WriteLine(vbCrLf & "***** MENU PRINCIPAL *****")
            Console.WriteLine("1. Consultar saldo")
            Console.WriteLine("2. Retirar efectivo")
            Console.WriteLine("3. Salir")
            Console.Write("Seleccione una opcion: ")

            If Integer.TryParse(Console.ReadLine(), opcion) Then
                Select Case opcion
                    Case 1
                        ConsultarSaldo()
                    Case 2
                        RetirarDinero()
                    Case 3
                        Console.WriteLine("Gracias por usar el cajero. Hasta luego")
                        Exit Do
                    Case Else
                        Console.WriteLine("Opcion invalida, intente de nuevo. ")
                End Select
            Else
                Console.WriteLine("Entrada invalidad, por favor ingrese un numero. ")
            End If
        Loop
    End Sub

    Sub ConsultarSaldo()
        Console.WriteLine("Su saldo actual es: $" & saldo)
    End Sub

    Sub RetirarDinero()
        Dim monto As Decimal
        Console.Write("Ingrese el monto a retirar (multiplo de 5): ")

        If Decimal.TryParse(Console.ReadLine(), monto) Then
            If monto Mod 5 <> 0 Then
                Console.WriteLine("Error: El monto debe ser multiplo de 5. ")
            ElseIf monto > saldo Then
                Console.WriteLine("Error: Saldo insuficiente. ")

            Else
                saldo -= monto
                Console.WriteLine("Retiro exitoso. Su nuevo saldo es: $" & saldo)
            End If

        Else
            Console.WriteLine("Error: Ingrese un numero valido.")
        End If
    End Sub
End Module
