use RestaurantsDb
select u.Email,r.Name	 from AspNetUserRoles as UR
left join AspNetUsers U 
on ur.UserId=u.Id
join AspNetRoles R
on r.Id=UR.RoleId;