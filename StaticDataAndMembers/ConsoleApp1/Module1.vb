Imports CarLibrary
Module Module1

    Sub Main()
        Dim myMiniVan As New MiniVan
        myMiniVan.TurboBoost()
        Dim mySportCar As New SportsCar
        mySportCar.TurboBoost()
        Dim dreamCar As New PerformanceCar()
        ' Использовать унаследованное свойство.
        dreamCar.PetName = "Hank"
        dreamCar.TurboBoost()
        Console.ReadLine()

    End Sub

End Module
