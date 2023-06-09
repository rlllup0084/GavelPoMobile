﻿using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Web;

namespace GavelPoMobile.Maui.ViewModels;

public class PurchaseOrderViewModel : BaseViewModel, IQueryAttributable {
    private int id;
    private string referenceNo;
    private int status;
    private string remarks;
    private decimal total;
    private string sourceNo;
    private DateTime entryDate;
    private string vendorName;
    private List<PurchaseOrderDetail> purchaseOrderDetails = new();
    private string statusIcon;
    private bool isRemarksDirty = false;

    private bool isLoading = true;
    //private bool isModified = false;

    private string oldRemarks;
    private string retRemarks;

    private string btnApproveText;
    private string btnDisapproveText;
    private string errorText;
    private bool hasError;

    public string BtnApproveText {
        get => btnApproveText;
        set => SetProperty(ref btnApproveText, value);
    }

    public string BtnDisapproveText {
        get => btnDisapproveText;
        set {
            string oldBtnText = btnDisapproveText;
            SetProperty(ref btnDisapproveText, value);
            if (oldBtnText != "Cancel") {
                retRemarks = oldRemarks;
            }
        }
    }

    public int Id {
        get => id;
        set => SetProperty(ref id, value);
    }

    public string StatusIcon {
        get => statusIcon;
        set => SetProperty(ref statusIcon, value);
    }
    public string ReferenceNo {
        get => referenceNo;
        set => SetProperty(ref referenceNo, value);
    }
    public int Status {
        get => status;
        set => SetProperty(ref status, value);
    }
    public string Remarks {
        get => remarks;
        set {
            oldRemarks = remarks;
            SetProperty(ref remarks, value);
            if (!isLoading && oldRemarks != value) {
                IsRemarksDirty = true;
                BtnApproveText = "Save";
                BtnDisapproveText = "Cancel";
            }
        }
    }
    public decimal Total {
        get => total;
        set => SetProperty(ref total, value);
    }
    public string SourceNo {
        get => sourceNo;
        set => SetProperty(ref sourceNo, value);
    }
    public DateTime EntryDate {
        get => entryDate;
        set => SetProperty(ref entryDate, value);
    }
    public string VendorName {
        get => vendorName;
        set => SetProperty(ref vendorName, value);
    }
    public List<PurchaseOrderDetail> PurchaseOrderDetails {
        get => purchaseOrderDetails;
        set => SetProperty(ref purchaseOrderDetails, value);
    }

    public bool IsRemarksDirty {
        get => isRemarksDirty;
        set => SetProperty(ref isRemarksDirty, value);
    }

    public string ErrorText {
        get => errorText;
        set => SetProperty(ref errorText, value);
    }

    public bool HasError {
        get => hasError;
        set => SetProperty(ref hasError, value);
    }


    public PurchaseOrderViewModel() {
        ShowDetailsCommand = new Command(ExecuteShowDetailsCommand);
        ApproveCommand = new Command(ExecuteApproveCommand);
        DisapproveCommand = new Command(ExecuteDisapproveCommand);
        PendingCommand = new Command(ExecutePendingCommand);
    }

    async void ExecutePendingCommand() {
        // Pending == 5
        var response = await PurchaseOrderService.UpdatePurchaseOrderStatus(this.id, 5, this.remarks);
        if (!string.IsNullOrEmpty(response)) {
            var errorData = JsonConvert.DeserializeObject<ErrorData>(response);
            ErrorText = errorData.Title;
            HasError = true;
            return;
        }
        HasError = false;
        StatusIcon = "pending.png";
        await Navigation.GoBackAsync(this.id);
    }

    async void ExecuteDisapproveCommand() {
        // Disapprove == 4
        if (btnDisapproveText == "Disapprove") {
            var response = await PurchaseOrderService.UpdatePurchaseOrderStatus(this.id, 4, this.remarks);
            if (!string.IsNullOrEmpty(response)) {
                var errorData = JsonConvert.DeserializeObject<ErrorData>(response);
                ErrorText = errorData.Title;
                HasError = true;
                return;
            }
            HasError = false;
            StatusIcon = "disapprove.png";
            await Navigation.GoBackAsync(this.id);
        } else if (btnDisapproveText == "Cancel") {
            Remarks = retRemarks;
            BtnApproveText = "Approve";
            BtnDisapproveText = "Disapprove";
        }
    }

    async void ExecuteApproveCommand() {
        // Approve == 1
        if (btnApproveText == "Approve") {
            var response = await PurchaseOrderService.UpdatePurchaseOrderStatus(this.id, 1, this.remarks);
            if (!string.IsNullOrEmpty(response)) {
                var errorData = JsonConvert.DeserializeObject<ErrorData>(response);
                ErrorText = errorData.Title;
                HasError = true;
                return;
            }
            HasError = false;
            StatusIcon = "approve.png";
            await Navigation.GoBackAsync(this.id);
        } else if (btnApproveText == "Save") {
            var response = await PurchaseOrderService.UpdatePurchaseOrderStatus(this.id, this.status, this.remarks);
            if (!string.IsNullOrEmpty(response)) {
                var errorData = JsonConvert.DeserializeObject<ErrorData>(response);
                ErrorText = errorData.Title;
                HasError = true;
                return;
            }
            HasError = false;
            BtnApproveText = "Approve";
            BtnDisapproveText = "Disapprove";
        }
    }

    private async void ExecuteShowDetailsCommand() {
        await Navigation.NavigateToAsync<PurchaseOrderDetailsViewModel>(id.ToString());
    }

    public async Task LoadPurchaseOrderId(string purchaseOrderId) {
        var response = await PurchaseOrderService.GetPurchaseOrderById(Convert.ToInt32(purchaseOrderId));

        try {
            var purchaseOrder = JsonConvert.DeserializeObject<PurchaseOrderMasterDetails>(response);
            Title = purchaseOrder.SourceNo;
            switch (purchaseOrder.Status) {
                case 0:
                    StatusIcon = "current.png";
                    break;
                case 1:
                    StatusIcon = "approve.png";
                    break;
                case 2:
                    StatusIcon = "approve.png";
                    break;
                case 3:
                    StatusIcon = "approve.png";
                    break;
                case 4:
                    StatusIcon = "disapprove.png";
                    break;
                case 5:
                    StatusIcon = "pending.png";
                    break;
                default:
                    break;
            }
            Id = purchaseOrder.Id;
            ReferenceNo = purchaseOrder.ReferenceNo;
            Status = purchaseOrder.Status;
            Remarks = purchaseOrder.Remarks;
            Total = purchaseOrder.Total;
            SourceNo = purchaseOrder.SourceNo;
            EntryDate = purchaseOrder.EntryDate;
            VendorName = purchaseOrder.VendorName;
            PurchaseOrderDetails.AddRange(purchaseOrder.PurchaseOrderDetails);
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Technical Difficulties", "Please ask your system administrator for assistance or try again later.", "OK");
        } finally {
            isLoading = false;
            BtnApproveText = "Approve";
            BtnDisapproveText = "Disapprove";
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query) {
        string id = HttpUtility.UrlDecode(query["id"] as string);
        await LoadPurchaseOrderId(id);
    }

    // ShowDetailsCommand
    public Command ShowDetailsCommand { get; }
    // ApproveCommand
    public Command ApproveCommand { get; }
    // DisapproveCommand
    public Command DisapproveCommand { get; }
    // PendingCommand
    public Command PendingCommand { get; }
}
