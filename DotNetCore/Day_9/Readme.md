
# .NET Core & ASP.NET Core - Practice Activities

	# What is asked? 

		1. Build a simple Razor Pages application
		2. Implement form handling using POST
		3. Serve static files
		4. Explore middleware customization

	# What we will do?

		### Activity 1: Build a simple Razor Pages application
			- Create a new Razor Pages project using `dotnet new webapp`
			- Understand the project structure (/Pages and /wwwroot folders)
			- Run the application using `dotnet run`

		### Activity 2: Implement form handling using POST
			- Create a Razor Page with an input form
			- Use `[BindProperty]` in PageModel to bind form data
			- Implement `OnPost()` method to process user input
			- Display submitted data on the page

		### Activity 3: Serve static files
			- Add a `wwwroot` folder (if not present)
			- Include static files such as CSS, JavaScript, or images
			- Enable `app.UseStaticFiles()` in Program.cs
			- Reference static files in Razor pages using `~/` path

		### Activity 4: Explore middleware customization
			- Study the default middleware pipeline in Program.cs
			- Add custom middleware using `app.Use()` or `app.Run()`
			- Implement a simple logging middleware to track requests
			- Understand the order of middleware execution
