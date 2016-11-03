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
                "valid_children": ["folder", "leaf"],
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

    function CreateNode(node) {
        if (node === false) return;

        var node = tree.get_node(node);
        if (node.type == "leaf") {
            tree.set_type(node, "folder");
        }

        var leafNode = tree.create_node(node, { "type": "leaf", "state": "selected", "text": "New node" });

        tree.edit(leafNode);
    }

    function RenameNode(node) {
        if (node === false) return;

        tree.edit(node);
    }

    function DeleteNode(node) {
        if (node === false) return;

        var parentNode = tree.get_parent(node);
        tree.delete_node(node);

        if (tree.is_leaf(parentNode)) {
            tree.set_type(parentNode, "leaf");
        }
    }

    function customMenu(node) {
        var items = {
            create: {
                "label": "Create",
                "action": function (data) {
                    CreateNode(data.reference);
                }
            },
            rename: {
                "label": "Rename",
                "action": function (data) {
                    RenameNode(data.reference);
                }
            },
            deleteOption: {
                "label": "Delete",
                "action": function (data) {
                    DeleteNode(data.reference);
                }
            }
        }

        if (node.type == "root") {
            delete items.rename;
            delete items.deleteOption;
        }

        return items;
    }

    //buttons click handlers

    $("#add").on("click", function () {
        var selectedNode = tree.get_selected(true)[0];
        var type = tree.get_type(selectedNode);

        if (selectedNode === undefined) {
            var rootNode = tree.get_node("#root");
            CreateNode(rootNode);
        } else {
            CreateNode(selectedNode);
        }
    });

    $("#save").on("click", function () {

    });

    $("#cancel").on("click", function(){
        location.reload();
    });
});