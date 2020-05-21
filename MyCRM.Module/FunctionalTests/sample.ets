;#DropDB MyCRMEasyTest

#Application MyCRM.Win
#Application MyCRM.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef MyCRM.Win

*Action About...
 
*Action OK

#EndIf

#IfDef MyCRM.Web
*Action Navigation(My Details)
#EndIf
