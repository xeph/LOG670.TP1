-- Garage.checkRepairBrand
?ga.checkRepairBrand(ve1)
!create br3 : Brand
!set br3.Length := 3
!set br3.Name := 'Mazda'
!create ve3 : Vehicle
!insert (ve3, br3) into BrandLink
?ga.checkRepairBrand(ve1)