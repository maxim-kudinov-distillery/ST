$(function () {
    $('#jstree').jstree({
        "core": {
            "check_callback": true
        },
        "types": {
            "#": {
                "max_children": 1,
            },
            "root": {
                "icon": "/Content/jsTree/themes/default/root.png"
            },
            "folder": {
                "icon": "/Content/jsTree/themes/default/folder.png"
            },
            "leaf": {
                "icon": "/Content/jsTree/themes/default/leaf.png"
            }
        },
        "checkbox": {
            "three_state": false,
            "tie_selection": false,
            "whole_node": false
        },
        "plugins": ["wholerow", "types", "checkbox"]
    });

    var tree = $("#jstree").jstree(true);

    //make root unselectable
    var rootNode = tree.get_node("root");
    tree.disable_checkbox(rootNode);
    $("#root_anchor > i.jstree-checkbox").hide();

    //mark categories checked
    var categoriesToCheck = $("#categoriesTree").attr("data-selected").split(",").filter(function (value) { return value != "" });
    $.each(categoriesToCheck, function (index, value) {
        tree.check_node(value)
    });

    function UpdateObject() {

        var formDataJson = GetData();
        var checkedCategories = tree.get_checked();
        formDataJson.Product.Categories = [];
        $.each(checkedCategories, function (index, category) {
            formDataJson.Product.Categories.push({id: category});
        });
        
        var jsonString = JSON.stringify(formDataJson);
        AjaxRequest("/Products/ProductsSaveData", jsonString);
    }

    function DeleteObject(id) {

        var data = '{ id : ' + id + '}'
        AjaxRequest("/Products/ProductDelete", data);
    }

    function AjaxRequest(url, data) {

        $.ajax({
            type: "POST",
            url: url,
            contentType: 'application/json; charset=utf-8',
            data: data,
            cache: false,
            dataType: "json",
            success: function (data) {

                if (!data.ValidationError) {
                    UpdateSuccess();
                }

                //Display message if any
                if (data.Message) {
                    alert(data.Message);
                }

                //Redirect if any url
                if (data.RedirectUrl) {
                    window.location = data.RedirectUrl;
                }

                //Display error if any
                if (data.ValidationError) {
                    alert(data.ValidationError);
                }


            },
            failure: function (data) {
                alert("errorOccurredText");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("errorOccurredText");
            }
        });
    }

    function UpdateSuccess() {
        window.location = "/Products";
    }

    function LoadInputData(id) {

        window.location = "Products?id=" + id;
    }

    function ToggleNewEdit() {

        var id = GetInputHiddenVal("objId");

        if (id > 0) {
            $("#headline").text("Edit product");
            $("#saveButton").val("Save changes");
            $("#cancelButton").show();
        }
        else {
            $("#headline").text("Add product");
            $("#saveButton").val("Save new product");
            $("#cancelButton").hide();
        }
    }

    function GetData() {
        var activeForm = $(".formData form");

        var response = activeForm.toObject({ skipEmpty: false });
        return response;
    }

    ToggleNewEdit();

    //Load edit button events in table
    $(document).on("click", ".listEdit", function () {
        var id = $(this).closest("tr").data("id");

        LoadInputData(id);
        return false;
    });

    //Load delete button events in table
    $(document).on("click", ".listDelete", function () {
        var id = $(this).closest("tr").data("id");

        DeleteObject(id);
        return false;
    });

    //Load cancel button event
    $(document).on("click", "#cancelButton", function () {
        window.location = "Products";
    });

    //Load submit event
    $(".formData").on("submit", "form", function () {

        if ($(this).valid()) {

            //Proceed with updates
            UpdateObject();
        }
        return false;
    });
});