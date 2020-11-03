create proc ElementosTIPorDepartamento
as
Select departamento.id as 'Departamento', departamento.nombre, count(elementoTI.id) as 'Cantidad de elementos'  From elementoTI
Inner Join elementoTI_departamento
On elementoTI_departamento.fk_elementoTI = elementoTI.id
Inner Join departamento
On departamento.id = elementoTI_departamento.fk_departamento
Group By departamento.id, departamento.nombre
Order by COUNT(departamento.id) DESC
go

Exec ElementosTIPorDepartamento









