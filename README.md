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

### Token claims
![image](https://user-images.githubusercontent.com/30668073/60503060-41509f00-9cbf-11e9-8961-70691976fb5c.png)
