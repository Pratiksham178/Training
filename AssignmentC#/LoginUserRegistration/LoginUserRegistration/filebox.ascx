<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="filebox.ascx.cs" Inherits="LoginUserRegistration.filebox" %>
<div id="fileinputbox">
    <div ID="message_file" runat="server" clientIDmode="Static" class="message"></div>
    <div id="filebox1" runat="server" clientIDmode="Static">
        
    </div>
    <div class="uploadbox">
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/> 
        <asp:button runat="server" ID="uploadBtn" Text="Upload"  cssclass="btn_upload"/> 
    </div>
    <div id="uploadFileText" runat="server" clientIDmode="Static"></div>
</div>

