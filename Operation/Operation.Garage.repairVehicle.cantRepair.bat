-- Operation.Garage.repairVehicle.cantRepair
!set ga.Position := 6
!create gw3 : GlobalWeather
!set gw3.SafeDistanceRatio := 0.95
!create ch3 : CheckEngine
!set ch3.isOk := false
!create br3 : Brand
!set br3.Name := 'Mazda'
!create na3 : Navigator
!insert (na3, gw3) into GlobalWeatherLink
!insert (na3, ch3) into CheckEngineLink
!create ve3 : Vehicle
!set ve3.Position := 6
!insert (ve3, br3) into BrandLink
!insert (ve3, na3) into NavigatorLink