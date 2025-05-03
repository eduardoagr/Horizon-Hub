namespace HorizonHub.Helpers {

    public class MicrosoftAuthHelper(InteractiveBrowserCredential credential) {

        public async Task<string?> GetAccessTokenAsync() {
            var tokenRequestContext = new TokenRequestContext(["https://graph.microsoft.com/.default"]);
            var accessToken = await credential.GetTokenAsync(tokenRequestContext, CancellationToken.None);

            Debug.WriteLine($"Access Token: {accessToken.Token}");
            return accessToken.Token;
        }
    }
}
