## CrispChat.Net

A .Net API wrapper for the [Crisp Chat API](https://docs.crisp.chat/references/rest-api/v1/).

## Disclaimer

The library is just developed as a simple POC API warpper in .Net and is not for actual use ~~yet~~.

## Features

Right now only few conversation related API methods under Website are available.

## Usage

```C#
using CrispChat.Net;
using CrispChat.Net.Services;

var client = new CrispClient(
    "Website Id",
    "Token Identifier",
    "Token Key"
);

var websiteService = client.WebsiteService;

var result = await websiteService.CreateConversationAsync();

```

## License

CrispChat.Net is licensed under [MIT License](https://github.com/thevenuz/CrispChat.Net/blob/master/LICENSE).
