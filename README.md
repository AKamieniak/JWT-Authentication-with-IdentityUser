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

### Create token 
- based on User credentials 
