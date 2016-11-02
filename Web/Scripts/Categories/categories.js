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
                "action": function (obj) {
                }
            },
            rename: {
                "label": "Rename",
                "action": function (obj) {
                }
            },
            deleteOption: {
                "label": "Delete",
                "action": function (obj) {
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
});