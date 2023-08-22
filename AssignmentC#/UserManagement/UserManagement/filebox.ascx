<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="filebox.ascx.cs" Inherits="UserManagement.filebox" %>
<div id="fileinputbox">
    <div ID="message_file"  class="message"></div>
    <div id="filebox1" >
        
    </div>
    <div class="uploadbox">
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/> 
        <asp:Button runat="server" ID="uploadBtn" Text="Upload"  cssclass="btn_upload" type="button"/> 
    </div>
    <div id="uploadFileText" ></div>
</div>

