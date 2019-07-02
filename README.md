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

## Token 
### Claims: UserId, UserName, Email, Role 

To decode token go to: https://jwt.io/ 
![image](https://user-images.githubusercontent.com/30668073/60503060-41509f00-9cbf-11e9-8961-70691976fb5c.png)

## Swagger
### Create token
![image](https://user-images.githubusercontent.com/30668073/60503229-912f6600-9cbf-11e9-99e3-c1eec2ce4eb8.png)

