using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RecoCms6.Models;

namespace RecoCms6.Pages
{
    public partial class AddLossCauseTagComponent : ComponentBase, IDisposable
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }

        public void Dispose()
        {
            Globals.PropertyChanged -= OnPropertyChanged;
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected RecoDbService RecoDb { get; set; }

        [Parameter]
        public dynamic ClaimID { get; set; }

        [Parameter]
        public dynamic LossCauseID { get; set; }
        protected RadzenGrid<RecoCms6.Models.RecoDb.LossCauseTag> gridLossCauseTags;

        RecoCms6.Models.RecoDb.LossCauseTag _losscausetag;
        protected RecoCms6.Models.RecoDb.LossCauseTag losscausetag
        {
            get
            {
                return _losscausetag;
            }
            set
            {
                if (!object.Equals(_losscausetag, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "losscausetag", NewValue = value, OldValue = _losscausetag };
                    _losscausetag = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.LossCauseTag> _getLossCauseTagList;
        protected IEnumerable<RecoCms6.Models.RecoDb.LossCauseTag> getLossCauseTagList
        {
            get
            {
                return _getLossCauseTagList;
            }
            set
            {
                if (!object.Equals(_getLossCauseTagList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getLossCauseTagList", NewValue = value, OldValue = _getLossCauseTagList };
                    _getLossCauseTagList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _LossCauseText;
        protected string LossCauseText
        {
            get
            {
                return _LossCauseText;
            }
            set
            {
                if (!object.Equals(_LossCauseText, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "LossCauseText", NewValue = value, OldValue = _LossCauseText };
                    _LossCauseText = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _selectedPopularTag;
        protected string selectedPopularTag
        {
            get
            {
                return _selectedPopularTag;
            }
            set
            {
                if (!object.Equals(_selectedPopularTag, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "selectedPopularTag", NewValue = value, OldValue = _selectedPopularTag };
                    _selectedPopularTag = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.LossCauseTagCount> _getTop5Tags;
        protected IEnumerable<RecoCms6.Models.RecoDb.LossCauseTagCount> getTop5Tags
        {
            get
            {
                return _getTop5Tags;
            }
            set
            {
                if (!object.Equals(_getTop5Tags, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTop5Tags", NewValue = value, OldValue = _getTop5Tags };
                    _getTop5Tags = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            losscausetag = new RecoCms6.Models.RecoDb.LossCauseTag() { };

            losscausetag.ClaimID = ClaimID;

            var recoDbGetLossCauseTagsResult = await RecoDb.GetLossCauseTags(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID }, OrderBy = $"LossCauseTag1 asc" });
            getLossCauseTagList = recoDbGetLossCauseTagsResult;

            LossCauseText = "";

            selectedPopularTag = "";

            var recoDbGetLossCauseTagCountsResult = await RecoDb.GetLossCauseTagCounts(new Query() { Filter = $@"i => i.LossCauseID == @0", FilterParameters = new object[] { LossCauseID }, OrderBy = $"LossCauseTag asc", Top = 5 });
            getTop5Tags = recoDbGetLossCauseTagCountsResult;
        }

        protected async System.Threading.Tasks.Task ButtonAddLossCauseTagClick(MouseEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(LossCauseText))
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Unable to Add Tag", Detail = $"Please write a tag before adding" });
                return;
            }

            if (getLossCauseTagList.Any(lt => lt.LossCauseTag1 == LossCauseText))
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Loss Cause Already Saved" });
                return;
            }

            losscausetag.LossCauseTag1 = LossCauseText.Trim();

            var recoDbCreateLossCauseTagResult = await RecoDb.CreateLossCauseTag(losscausetag);
            await gridLossCauseTags.Reload();

            LossCauseText = "";
        }

        protected async System.Threading.Tasks.Task ButtonDeleteClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbDeleteLossCauseTagResult = await RecoDb.DeleteLossCauseTag(data.ClaimID, $"{data.LossCauseTag1}");
                await gridLossCauseTags.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddSelectedTagClick(MouseEventArgs args)
        {
            if (selectedPopularTag == "")
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Unable to Add Popular Tag", Detail = $"Please select a tag before adding" });
                return;
            }

            if (getLossCauseTagList.Any(lt => lt.LossCauseTag1 == selectedPopularTag))
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = "Loss Cause Already Saved" });
                return;
            }

            losscausetag.LossCauseTag1 = selectedPopularTag;

            var recoDbCreateLossCauseTagResult = await RecoDb.CreateLossCauseTag(losscausetag);
            await gridLossCauseTags.Reload();
        }

        protected async System.Threading.Tasks.Task ButtonCloseDialogClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
