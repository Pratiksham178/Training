<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteBox.ascx.cs" Inherits="LoginUserRegistration.NoteBox" %>
<div id="noteBox" runat="server">
    
        <div id="message" runat="server" ClientIDMode="Static" class="message"></div>
    <div id="userNotes" runat="server" ClientIDMode="Static" class="usernotes"></div>
    <div id="companymessage" runat="server" ClientIDMode="Static" class="message"></div>
    <div id="companyNotes" runat="server" ClientIDMode="Static" class="usernotes"></div>
   <div class="note_input" runat="server" ClientIdMode="static" id="note_input_box">
       <asp:CheckBox ID="checkBoxForPrivateMessage" runat="server" ClientIDMode="Static"/>
        <asp:Textbox ID="addNoteTextBox" runat="server" TextMode="MultiLine" ClientIDMode="Static" ></asp:Textbox>
       
    <asp:Button ID="addNote" runat="server" OnClick="AddNoteToDB" Text="Add Note" CssClass="btn_AddNote" ClientIDMode="Static" />

           </div>
    <span id="privatemessage" runat="server" ClientIDMode="Static"></span>
    
    
</div>