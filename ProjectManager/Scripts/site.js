
/////////////
//Page Load//
/////////////

$(document).ready(function () {
    loadSideBarFolders();
    eventSideBarAddFolder();
    setupTreeView();
});

////////////
//Side Bar//
////////////

//Folder Actions

function sideBarAddFolder()
{
    var description = $('#txtFolderDescription').val();
    var objPostFolder = $.post("/folder/add", { description: description }, function (data) {

        var listItem = '<li id="folder_' + data.id + '" folderId="' + data.id + '"><a>' + data.desc + '</a></li>';
        $(listItem).insertAfter($("#sideBarAddFolderListItem"));
        $('#txtFolderDescription').val('');
    })
     .fail(function () {
        alert('Unable to add the folder!');
        });

    $('#sideBarAddContainer').show();
    $('#sideBarAddContainerSubmit').hide();
}

function eventSideBarAddFolder()
{
    $('#sideBarAddFolder').click(function () {
        $('#sideBarAddContainer').hide();
        $('#sideBarAddContainerSubmit').show();
    });

    $('#txtFolderDescription').keypress(function (e) {
        var key = e.which;
        if (key == 13) {
            sideBarAddFolder();
            e.preventDefault();
        }
    });

    $('#txtFolderDescription').blur(function (e) {
        if ($('#sideBarAddContainerSubmit').is(":visible"))
        {
            sideBarAddFolder();
            e.preventDefault();
        }
        
    });
}

//Load all the folders into the sidebar
function loadSideBarFolders()
{
    var treeViewAjaxUrl = $('#loadSideBarFoldersUrl').val();

    $.get(treeViewAjaxUrl, function (data) {
        $(data).insertAfter($("#sideBarAddFolderListItem"));
    });
}

//Load the Sub Items for a folder
function loadSideBarFolderChildren(sender)
{
    $.get('/folder/children/' + folderId, function (data) {
        $(data).insertAfter($("#sideBarAddFolderListItem"));
    });
}

//Tree View Setup

function setupTreeView()
{
    $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
    $('.tree li.parent_li > span').on('click', function (e) {
        var children = $(this).parent('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            children.hide('fast');
            $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
        } else {
            children.show('fast');
            $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
        }
        e.stopPropagation();
    });
}