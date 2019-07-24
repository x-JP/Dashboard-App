#pragma checksum "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90def1072c735679fb5f77cabcdfc300e8c81344"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Dashboard.Pages
{
    #line hidden
    using System.Linq;
    using Microsoft.AspNetCore.Components;
#line 2 "F:\CODE\AllianzGI-Dashboard\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "F:\CODE\AllianzGI-Dashboard\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Layouts;

#line default
#line hidden
#line 4 "F:\CODE\AllianzGI-Dashboard\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "F:\CODE\AllianzGI-Dashboard\Dashboard\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "F:\CODE\AllianzGI-Dashboard\Dashboard\_Imports.razor"
using Dashboard;

#line default
#line hidden
#line 7 "F:\CODE\AllianzGI-Dashboard\Dashboard\_Imports.razor"
using Dashboard.Shared;

#line default
#line hidden
#line 3 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System;

#line default
#line hidden
#line 4 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System.Net;

#line default
#line hidden
#line 5 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System.Net.Http;

#line default
#line hidden
#line 6 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#line 7 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System.Threading.Tasks;

#line default
#line hidden
#line 9 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System.Collections.Generic;

#line default
#line hidden
#line 10 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
using System.Runtime.Serialization.Json;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 60 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
            
  private static async Task GetBatchDetails(int BatchGUID)
  {
    //Index.selectedBatchGUID = BatchGUID;
    Console.WriteLine(BatchGUID);
    Console.WriteLine("http://localhost:3000/api/tradeinformationonbatches/" + BatchGUID);
    var streamTask = client.GetStreamAsync("http://localhost:3000/api/tradeinformationonbatches/" + BatchGUID);

    try {
      Index.trades = tradeSerializer.ReadObject(await streamTask) as List<Trade>;
    } catch {
      Index.trades.Clear(); // create empty list
    }

    for (var i = 0; i < trades.Count; i++) {
      Console.WriteLine(trades[i].TradeId);
    }
  }

  private void update() {
    Console.WriteLine("update");
    StateHasChanged();
  }

  
  private async void FetchData()
  {

    var streamTask = client.GetStreamAsync("http://localhost:3000/api/guidelinecheckdurations");
    batches = batchSerializer.ReadObject(await streamTask) as List<Batch>;

    var streamTask2 = client.GetStreamAsync("http://localhost:3000/api/accountscheckedinbatch");
    batchQuantities = batchQuantitySerializer.ReadObject(await streamTask2) as List<BatchQuantity>;
    /*foreach (var batch in batches)
        Console.WriteLine(batch.Queued + "  duration: " + batch.QueueDuration);*/
  }

  private async void DisplayGraph1()
  {
      await JsRuntime.InvokeAsync<int>("displayGraph1", batches);
      StateHasChanged();
  }

  private async void DisplayGraph2()
  {
      await JsRuntime.InvokeAsync<int>("displayGraph2", batchQuantities, batches);
      StateHasChanged();
  }

#line default
#line hidden
#line 111 "F:\CODE\AllianzGI-Dashboard\Dashboard\Pages\Index.razor"
       
    private static readonly HttpClient client = new HttpClient();
    private static DataContractJsonSerializer batchSerializer = new DataContractJsonSerializer(typeof(List<Batch>));
    private static DataContractJsonSerializer batchQuantitySerializer = new DataContractJsonSerializer(typeof(List<BatchQuantity>));
    private static DataContractJsonSerializer tradeSerializer = new DataContractJsonSerializer(typeof(List<Trade>));

    public static List<Batch> batches;
    public static List<BatchQuantity> batchQuantities;
    public static List<Trade> trades = new List<Trade>();
    private static int _selectedBatchGUID;
    public static int selectedBatchGUID { 
      get {
        Console.WriteLine("batch getted: " + _selectedBatchGUID);
        return _selectedBatchGUID;
        }
      set{
        Console.WriteLine("batch input update: ->>>>> " + value);
        GetBatchDetails(value);
        _selectedBatchGUID = value;
      }
    }// = -1;



#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
    }
}
#pragma warning restore 1591
