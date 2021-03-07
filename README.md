# Authentication 
.Net Core 5.0 projects aimed at understanding Authentication and Authorization \
This project is created using reference from this Youtube tutorial https://www.youtube.com/playlist?list=PLOeFnOV9YBa7dnrjpOG6lMpcyd7Wn7E8V

This solution has multiple projects as described below
1. **Basics:** This project teaches you \
a. how to create a claim object, \
b. how to create identity from claim, \
c. how to configure authentication and authorization in your Startup.cs class

2. **IdentityExample** This project teaches you what the Identity package provides to us in terms of authentication infrastructure, specifically we try to disect the UserManager and the SignInManager. We also take a look at how to connect it with entity framework.
Steps:
1. Install packages for this \
a. Microsoft.EntityFrameworkCore \
b. Microsoft.EntityFrameworkCore.InMemory \
c. Microsoft.AspNetCore.Identity.EntityFrameworkCore

2. Create an AppDbContext class and use IdentityDbContext as base class
3. In your startup.cs file inject AppDbContext and configure it to use in memory db
4. In your startup.cs file add Identity and use IdentityUser and IdentityRole inbuilt classes
5. Create a home controller. the purpose of this controller is to create login, register, signout, secret and index methods. Secret method can be called by only Authenticated user meaning the user who has the cookie in their browser
6. Create views for home page, secret page, login page and register page
7. Using dependency injection inject UserManager<IdentityUser> in your controller. UserManager class is used to do all kind of authentication for us. It can create users, signin user, signout user etc.
8. In the register method we need to use CreateAsync method of usermanager class. This method will need two parameters. One will be IdentityUser and other will be password. So create an identity user and password is passed to the method. 
9. Once the user is registered we need to sign in the user and for that we need to inject signinmanager as a dependency
