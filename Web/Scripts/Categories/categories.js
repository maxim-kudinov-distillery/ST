$(function () {
    $('#jstree').jstree({
        "core": {
            "check_callback": true
        },
        "types": {
            "#": {
                "max_children": 1,
                "Valid_children": ["root"]
            },
            "root": {
                "valid_children": ["folder"],
                "icon": "/Content/jsTree/themes/default/root.png"
            },
            "folder": {
                "valid_children": ["folder", "leaf"],
                "icon": "/Content/jsTree/themes/default/folder.png"
            },
            "leaf": {
                "valid_children": [],
                "icon": "/Content/jsTree/themes/default/leaf.png"
            }
        },
        "contextmenu": {
            items: customMenu
        },
        "plugins": ["wholerow", "dnd", "types", "contextmenu"]
    });

    function customMenu(node) {
        var items = {
            create: {
                "label": "Create",
                "action": function (node) {
                }
            },
            rename: {
                "label": "Rename",
                "action": function (node) {
                    var iconSize = 24;
                    var padding = 2;
                    $("#nameInput").offset({top: node.position.y - iconSize, left: node.position.x + iconSize + padding}).show();
                }
            },
            deleteOption: {
                "label": "Delete",
                "action": function (node) {
                }
            }
        }

        if (node.type == "root") {
            delete items.create;
            delete items.rename;
            delete items.deleteOption;
        }

        return items;
    }

    //buttons click handlers

    $("#addFolder").on("click", function() {
        var tree = $("#jstree").jstree(true);
             
    });

    $("#cancel").on("click", function(){
        location.reload();
    });

    //inline input buttons handlers
    $("#nameInput").on( "keyup", function (e) {
        if (e.keyCode == 27) { //escape
            $(this).val("");
            $(this).hide();
        } else if (e.keyCode == 13) { //enter
            //rename node
            $(this).hide();
        }
    });
});