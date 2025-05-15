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
    public partial class AddNoteComponent : ComponentBase, IDisposable
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
        public dynamic NoteID { get; set; }

        [Parameter]
        public dynamic ClaimID { get; set; }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getNoteTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getNoteTypeList
        {
            get
            {
                return _getNoteTypeList;
            }
            set
            {
                if (!object.Equals(_getNoteTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getNoteTypeList", NewValue = value, OldValue = _getNoteTypeList };
                    _getNoteTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _defaultNoteType;
        protected int defaultNoteType
        {
            get
            {
                return _defaultNoteType;
            }
            set
            {
                if (!object.Equals(_defaultNoteType, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "defaultNoteType", NewValue = value, OldValue = _defaultNoteType };
                    _defaultNoteType = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Note _note;
        protected RecoCms6.Models.RecoDb.Note note
        {
            get
            {
                return _note;
            }
            set
            {
                if (!object.Equals(_note, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "note", NewValue = value, OldValue = _note };
                    _note = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Role> _roles;
        protected IEnumerable<RecoCms6.Models.RecoDb.Role> roles
        {
            get
            {
                return _roles;
            }
            set
            {
                if (!object.Equals(_roles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "roles", NewValue = value, OldValue = _roles };
                    _roles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimSearchList> _claimList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimSearchList> claimList
        {
            get
            {
                return _claimList;
            }
            set
            {
                if (!object.Equals(_claimList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimList", NewValue = value, OldValue = _claimList };
                    _claimList = value;
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
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "Note Type" }, OrderBy = $"ParamDesc asc" });
            getNoteTypeList = recoDbGetParameterDetailsResult;

            defaultNoteType = recoDbGetParameterDetailsResult.First(p=>p.ParamDesc=="Note").ParameterID;

            if (NoteID == Guid.Empty) {
                note = new RecoCms6.Models.RecoDb.Note(){};
            }

            if (NoteID == Guid.Empty) {
                note.ClaimID = ClaimID;
            }

            note.NoteTypeID = defaultNoteType;

            roles = new List<Role>();

            var recoDbGetClaimSearchListsResult = await RecoDb.GetClaimSearchLists(new Query() { OrderBy = $"ClaimNo desc" });
            claimList = recoDbGetClaimSearchListsResult;

            if (NoteID != Guid.Empty)
            {
                var recoDbGetNoteByIdResult = await RecoDb.GetNoteById(NoteID);
                note = recoDbGetNoteByIdResult;
            }
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Note args)
        {
            if (NoteID == Guid.Empty) {
                note.ID = Guid.NewGuid();
            }

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            note.EnteredByID = recoDbGetServiceProviderDetailsResult.First().Name;

            try
            {
                if (NoteID == Guid.Empty)
                {
                    var recoDbCreateNoteResult = await RecoDb.CreateNote(note);
                    DialogService.Close(note);
                }
            }
            catch (System.Exception recoDbCreateNoteException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Note" });
            }

            try
            {
                if (NoteID != Guid.Empty)
                {
                    var recoDbUpdateNoteResult = await RecoDb.UpdateNote(note.ID, note);
                    DialogService.Close(note);
                }
            }
            catch (System.Exception recoDbUpdateNoteException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable to Save Note" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
