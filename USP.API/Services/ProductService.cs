namespace USP.API.Services;

public class ProductService : IProductService
{
    public async Task<string> Get() => "Nedeljko";

    public async Task<string> Create() => "Created!";
}