public void ConfigureServices(IServiceCollection services)
{
	services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
		.AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

	services.AddControllersWithViews(options =>
	{
		var policy = new AuthorizationPolicyBuilder()
			.RequireAuthenticatedUser()
			.Build();
		options.Filters.Add(new AuthorizeFilter(policy));
	});
	services.AddRazorPages()
		.AddMicrosoftIdentityUI();
}