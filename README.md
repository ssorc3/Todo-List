# Todo App
This is a Todo app using .NET Core 6 and React.

## Questions
### How long did you spend on the solution?
The full solution took about 3 hours.

### How do you build and run your solution?
#### Requirements
- Node v16
- .Net Core 6

#### Starting the services
To start the backend, run these commands in this project's root directory:

``` sh
> cd Backend/Todo.Api
> DOTNET_URLS=https://localhost:5003 dotnet run --project Todo.Api
```

Then in another terminal, run these commands in this project's root directory to start the frontend:

``` sh
> cd Frontend/todo 
> npm install && npm start
```

These scripts will install the neccessary libraries and start the backend and the frontend.
The frontend will be accessible at `localhost:3000`.  
Testing in Firefox I found I had to go to `https://localhost:5003/todos` and click "Accept the risk and continue" before API requests would work with the front end.

### What technical and functional assumptions did you make when implementing your solution?
- The todos are not shown to everyone but are stored for each user.
- Users should not have to log in to use the app.
- No sensitive data would be stored in the app.
- In memory storage of todos in the backend would be sufficient for the demo.
- The entire design of the frontend application was assumed since there were no UI mockups.

### Briefly explain your technical design and why do you think this is the best approach to this problem.
#### User identification
Because I didn't want the user to have to log in to use the app, I implemented user identification using an identifier stored in local browser storage. When the page is first loaded, the browser generates a UUIDv4 identifier, which is sent with API requests.  
I decided on this design to make the demo simpler and to avoid assuming that a login system was needed, since that is not outlined in the specification. In the future, the userId in the request could be easily replaced with a JWT from an OAuth2 provider for example, which could then be verified on the backend and have the userId taken from there instead.  
The drawbacks of this method are that in theory, any user can see any other user's todos by manually changing the userId that is sent to the server. In theory users could also generate the same UUID as each other and get the same todos but in practice this is very unlikely. The lack of authentication means that no sensitive information should be stored in the todo items.

#### Storage
The todo items are stored in memory on the backend, using Entity Framework as a storage adapter. I chose this because it means that if a traditional database was required, it would be as simple as changing the startup options to include a database connection string and installing a different EF module. Using an in memory store for a demo means that the developer is not required to install a database just for the demo.
