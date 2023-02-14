// namespace Interview.Aterian.Core.Domain;
//
// public sealed class InventoryService
// {
//     private readonly ILogger _logger;
//     private readonly Inventory _inventory;
//     private readonly AllegroSellerAccounts _allegroSellerAccounts;
//     private readonly AllegroSellerSdk _allegroSeller;
//     private readonly AllegroOauthSdk _allegroOauth;
//     private readonly HttpClient _httpClient;
//     private readonly IConfiguration _configuration;
//     public InventoryService(
//         ILogger<InventoryService> logger,
//         Inventory inventory,
//         AllegroSellerAccounts allegroSellerAccounts,
//         AllegroSellerSdk allegroSeller,
//         AllegroOauthSdk allegroOauth,
//         HttpClient httpClient,
//         IConfiguration configuration)
//     {
//         _logger = logger;
//         _inventory = inventory;
//         _allegroSellerAccounts = allegroSellerAccounts;
//         _allegroSeller = allegroSeller;
//         _allegroOauth = allegroOauth;
//         _httpClient = httpClient;
//         _configuration = configuration;
//     }
//     public async Task UpdateInventory(Product product)
//     {
//         var inventory = await _inventory.GetFor(product);
//         if (product.IsSoldOn(SalesChannel.Allegro)) {
//             foreach (var sellerAccount in _allegroSellerAccounts)
//             {
//
//                 {
//                     var accessToken = _allegroOauth.GetAccessToken(
//                         sellerAccount.Id,
//                         sellerAccount.RefreshToken()).Result;
//                     allegroSeller.SetInventory(
//                         accessToken,
//                         new AllegroInventory(product.Id, inventory.Quantity())
//                     ).Result;
//                 }
//             }
//             if (product.IsSoldOn(SalesChannel.Website)) {
//                 using (var requestMessage =
//                        new HttpRequestMessage(HttpMethod.Get, "http://api.the-best-shop-ever.com/inventory/" + product.Id))
//                 {
//                     try
//                     {
//                         requestMessage.Headers.Authorization =
//                             new AuthenticationHeaderValue("Bearer", _configuration.["ATR_SHOP_API_SECRET"]);
//                         _logger.LogDebug(
//                             "Updating inventory for product {Product} to {Quantity} with {Request}",
//                             product.Id,
//                             inventory.Quantity(),
//                             requestMessage);
//                         var result = await httpClient.SendAsync(requestMessage);
//                         if (result.EnsureSuccessStatusCode())
//                         {
//                             throw new Exception("Error occurred when updating an inventory");
//                         }
//                     }
//                     catch(Exception ex)
//                     {
//                         _logger.LogError(ex.Message);
//                         throw new Exception(ex.Message);
//                     }
//                 }
//             }
//         }
//     }