<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="files.ascx.cs" Inherits="LoginUserRegistration.files" %>

<div id="fileinputbox">
    <div ID="message_file" runat="server" clientIDmode="Static" class="message"></div>
    <div id="filebox" runat="server" clientIDmode="Static">
        <asp:GridView ID="fileGridView" runat="server" clientIdMode="Static" AutoGenerateColumns="False" OnRowCommand="DeleteOrDownloadFile" DataKeyNames="filename">
            <Columns >
                 <asp:TemplateField HeaderText="File Name "> 
                            <ItemTemplate>  
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("filename") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField> 
                <asp:ButtonField Text="Download" HeaderText="Download" commandname="dwnld" />
                <asp:ButtonField Text="Delete" HeaderText="Delete" commandname="dlt" />
            </Columns>
            
        </asp:GridView>
    </div>
    <div class="uploadbox">
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/> 
        <asp:button runat="server" ID="uploadbtn" Text="Upload" OnClick="UploadFile" cssclass="btn_upload"/> 
    </div>
    <div id="uploadFileText" runat="server" clientIDmode="Static"></div>
</div>

