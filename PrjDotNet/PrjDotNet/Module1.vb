Imports ProjNet
Imports ProjNet.CoordinateSystems.Transformations
Imports ProjNet.CoordinateSystems

Module Module1
    Sub main()
        Dim xy(2) As Double
        xy(0) = 1689880.0
        xy(1) = 4738130.0
        Dim myLatLong(2) As Double

        'Public Function From3003To4326(ByVal xy As Double) As Double

        Dim wkt_EPSG3303 As String
        Dim wkt_WGS844326 As String
        Dim gcs_WGS84 As ICoordinateSystem
        Dim pcs_3003 As IProjectedCoordinateSystem

        Dim ctfac As New CoordinateTransformationFactory()
        Dim trans As ICoordinateTransformation

        pcs_3003 = ProjectedCoordinateSystem.WGS84_UTM(31, True)

        wkt_EPSG3303 = "PROJCS[""Monte Mario / Italy zone 1""," & _
         "GEOGCS[""Monte Mario""," & _
        "DATUM[""Monte_Mario""," & _
            "SPHEROID[""International 1924"",6378388,297," & _
                "AUTHORITY[""EPSG"",""7022""]]," & _
           " AUTHORITY[""EPSG"",""6265""]]," & _
        "PRIMEM[""Greenwich"",0," & _
            "AUTHORITY[""EPSG"",""8901""]]," & _
        "UNIT[""degree"",0.01745329251994328," & _
            "AUTHORITY[""EPSG"",""9122""]]," & _
        "AUTHORITY[""EPSG"",""4265""]]," & _
    "UNIT[""metre"",1," & _
        "AUTHORITY[""EPSG"",""9001""]]," & _
    "PROJECTION[""Transverse_Mercator""]," & _
    "PARAMETER[""latitude_of_origin"",0]," & _
    "PARAMETER[""central_meridian"",9]," & _
    "PARAMETER[""scale_factor"",0.9996]," & _
    "PARAMETER[""false_easting"",1500000]," & _
    "PARAMETER[""false_northing"",0]," & _
    "AUTHORITY[""EPSG"",""3003""]," & _
    "AXIS[""X"",EAST]," & _
    "AXIS[""Y"",NORTH]]"

        wkt_WGS844326 = "GEOGCS[""WGS 84""," & _
    "DATUM[""WGS_1984""," & _
        "SPHEROID[""WGS 84"",6378137,298.257223563," & _
            "AUTHORITY[""EPSG"",""7030""]]," & _
        "AUTHORITY[""EPSG"",""6326""]]," & _
    "PRIMEM[""Greenwich"",0," & _
        "AUTHORITY[""EPSG"",""8901""]]," & _
    "UNIT[""degree"",0.01745329251994328," & _
        "AUTHORITY[""EPSG"",""9122""]]," & _
    "AUTHORITY[""EPSG"",""4326""]]"

        gcs_WGS84 = Converters.WellKnownText.CoordinateSystemWktReader.Parse(wkt_WGS844326)
        pcs_3003 = Converters.WellKnownText.CoordinateSystemWktReader.Parse(wkt_EPSG3303)

        trans = ctfac.CreateFromCoordinateSystems(pcs_3003, gcs_WGS84)
        myLatLong = trans.MathTransform.Transform(xy)

        'End Function
        Console.WriteLine("Coordinate di partenza: x {0} , y {1}", xy(0), xy(1))
        Console.WriteLine("Coordinate convertite: lat {0} , long {1}", myLatLong(0), myLatLong(1))
        Console.ReadLine()
    End Sub
End Module
