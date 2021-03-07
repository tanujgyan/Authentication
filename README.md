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
9. Once the user is registered we need to sign in the user and for that we need to inject signinmanager as a dependency. And we will use PasswordSignInAsync method of the signinmanager
10. Create a logout method. Complete the signin method. Use usermanager method findbyidasync to get the user based on username
11. Launch the app and go to register page. try username=test and password=password. We should get a cookie in the application window in dev tools. if you dont get it go to vs 2019 output ASP .NET core webserver output window and check. There will be a warning like this \
warn: Microsoft.AspNetCore.Identity.UserManager[14]
      User password validation failed: PasswordRequiresNonAlphanumeric;PasswordRequiresDigit;PasswordRequiresUpper. \
  This means we need to configure the password requirements in startup class.
12. In the ConfigureServices method where we added the support for identity service. configure the password requirements there.
13. Use services.ConfigureApplicationCookie to set the login path and cookie name. The login path is needed so if someone tries to access a url directly without login they should be redirected to login page
