# JWT Authentication with IdentityUser

### User model
```c#
public class User : IdentityUser<int>, IEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? IsActive { get; set; }
}
```

## Example token 
- Claims:
```c#
var userRoles = await _userManager.GetRolesAsync(user);
var claims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    new Claim(ClaimTypes.Name, user.Name),
    new Claim(ClaimTypes.Email, user.Email),

};

claims.AddRange(userRoles.Select(claim => new Claim(ClaimTypes.Role, claim)));
```
- JWT token:
```JWT
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2IiwidW5pcXVlX25hbWUiOiJUZXN0MSIsImVtYWlsIjoidGVzdEB0ZXN0LmNvbSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTU2MjA1NzE5NCwiZXhwIjoxNTYyNjYxOTk0LCJpYXQiOjE1NjIwNTcxOTR9.Ni0UkA_2s1csKcm22XA354EheuXPBd6UzxkoqsRf5-A
```
Decoded Data:
```JSON
{
  "nameid": "6",
  "unique_name": "Test1",
  "email": "test@test.com",
  "role": "Admin",
  "nbf": 1562057194,
  "exp": 1562661994,
  "iat": 1562057194
}
```
To decode token go to: https://jwt.io/ 


## Swagger
### Create token
![image](https://user-images.githubusercontent.com/30668073/60503229-912f6600-9cbf-11e9-99e3-c1eec2ce4eb8.png)

