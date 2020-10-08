Select Inf_Customers.Customer_Name, Inf_Repair.Laptop_Name, Detail_Inf_Repair.Repair_Reason, Inf_LK.LK_Name 
from Inf_Customers 
	inner join Inf_Repair 
		on Inf_Customers.Customer_Id=Inf_Repair.Customer_Id 
	inner join Detail_Inf_Repair 
		on Inf_Repair.Repair_Id=Detail_Inf_Repair.Repair_Id
	inner join Inf_LK
		on Detail_Inf_Repair.LK_Id=Inf_LK.LK_Id 
and Inf_Customers.Customer_Id = 123