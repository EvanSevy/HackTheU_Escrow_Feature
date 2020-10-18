# HackTheU_Escrow_Feature

To run, open command prompt in the Angular 'ClientApp' folder, and run 'npm start'.  Then open a command prompt in the project folder and run 'dotnet watch run'.  Then open a window in a browser and go to:  https://localhost:5001/.  Then access the nav menu item called 'Create User'.  In the text box enter any name and press 'enter'.  This will call the API I started to create for the portion of the escrow feature of creating a user as a card holder in Galileo 'Instant'.

-->  If you don't wish to go this route to run the program and just want to run the project by clicking the debug/run button in Visual Studio, you can switch the commenting of these lines in the 'Startup.cs' file, towards the end:

//spa.UseAngularCliServer(npmScript: "start");

spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");

#########################

Infinity Heart Network enables you to express your wisdom and compassion within a social network of engaged contributors.  Fruitful discussions lead to powerful projects, making an impact on society.  A better future for everyone.

What I've done today, is made a great stride into implementing a project funding mechanism with Galileo 'Instant'.  The goal is to allow users to create philanthropic projects that may be funded by the community.  To do this I am creating and escrow account on the Project entity with the Galileo API's, allowing users to donate to the project.  

Unfortunately, I have been in the process of moving into a new house and had to stop early on my endeavors.

So far I've fleshed out the database schema, and I'm inches away from creating a Card Holder through the API.  I was able to make successful calls on the API through the C# HttpClient to acquire the sign-in tokens as well as the 'agreements' required for Card Holder creation.  In the future I will integrate this into the Infinity Heart Network project I've been creating.
