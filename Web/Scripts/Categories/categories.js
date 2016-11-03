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

    var tree = $("#jstree").jstree(true); 

    function CreateAction(data) {
        var parentNode = tree.get_node(data.reference);
        if (parentNode.type == "leaf") {
            tree.set_type(parentNode, "folder");
        }

        var createdNode = tree.create_node(parentNode, { "type": "leaf", "state": "selected", "text": "New node" });

        tree.edit(createdNode);
    }

    function RenameAction(data) {
        tree.edit(data.reference);
    }

    function DeleteAction(data) {
        var parentNode = tree.get_parent(data.reference);
        tree.delete_node(data.reference);

        if (tree.is_leaf(parentNode)) {
            tree.set_type(parentNode, "leaf");
        }
    }

    function customMenu(node) {
        var items = {
            create: {
                "label": "Create",
                "action": CreateAction 
            },
            rename: {
                "label": "Rename",
                "action": RenameAction
            },
            deleteOption: {
                "label": "Delete",
                "action": DeleteAction
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

    $("#addFolder").on("click", function () {

    });

    $("#cancel").on("click", function(){
        location.reload();
    });
});