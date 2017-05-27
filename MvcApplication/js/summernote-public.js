﻿var summernoteId = "";
function shuowSummernote(id,value)
{
    //加载编辑器
    summernoteId = id;
    $(id).summernote({
        height: 100,
        minHeight: null,
        maxHeight: null,
        focus: true,
        lang: 'zh-CN',
        // 重写图片上传  
        onImageUpload: function (files, editor, $editable) {
            sendFile(files[0], editor, $editable);
        }
    });
    $(id).summernote('code', value);// 赋值
    $(id).summernote('destroy');// 释放
}

//$('#summernote').summernote({
//    airPopover: [
//      ['color', ['color']],
//      ['font', ['bold', 'underline', 'clear']],
//      ['para', ['ul', 'paragraph']],
//      ['table', ['table']],
//      //['insert', ['link', 'picture']]
//    ]
//});
//图片上传  
function sendFile(file, editor, $editable) {

    var filename = false;
    try {
        filename = file['name'];
    } catch (e) {
        filename = false;
    }
    if (!filename) {
        $(".note-alarm").remove();
    }

    //以上防止在图片在编辑器内拖拽引发第二次上传导致的提示错误  
    data = new FormData();
    data.append("file", file);
    data.append("key", filename); //唯一性参数  

    $.ajax({
        data: data,
        type: "POST",
        url: "",
        cache: false,
        contentType: false,
        processData: false,
        success: function (url) {
            if (url == '200') {
                alert("上传失败！");
                return;
            } else {
                alert("上传成功！");
            }
            //alert(url);  
            editor.insertImage($editable, url);
            //setTimeout(function(){$(".note-alarm").remove();},3000);  
        },
        error: function () {
            alert("上传失败！");
            return;
            //setTimeout(function(){$(".note-alarm").remove();},3000);  
        }
    });
}

var edit = function (id) {
    $(id).summernote({ focus: true });//激活
};

var save = function (id) {
    var makrup = $('#summernote').summernote('code');// 取值
    $(id).summernote('destroy');// 释放
};
