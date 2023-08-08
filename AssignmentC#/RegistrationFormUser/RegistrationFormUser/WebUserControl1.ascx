<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="RegistrationFormUser.WebUserControl1" %>
<div id="noteBox" runat="server">
    <div id="message" runat="server" ClientIDMode="Static"></div>
    <div id="userNotes" runat="server" ClientIDMode="Static"></div>
   <div class="note_input">
        <asp:Textbox ID="addNoteTextBox" runat="server" TextMode="MultiLine" ClientIDMode="Static" ></asp:Textbox>
    <asp:Button ID="addNote" runat="server" OnClick="AddNoteToDB" Text="Add Note" CssClass="btn_AddNote" ClientIDMode="Static" />
   </div>
</div>