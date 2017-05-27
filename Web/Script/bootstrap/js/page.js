

var Page = {
    pageDiv: null,
    options: null,

    init: function (pageDiv, options, callback) {
        this.pageDiv = $(pageDiv);
        this.options = options || {};
        //濡傛灉娌℃湁浼犲叆index锛岃缃粯璁ゅ€间负1
        if (!this.options.index) {
            this.options.index = 1;
        }
        //娓叉煋鍒嗛〉
        this.render();

        //浠ｇ悊缁戝畾浜嬩欢
        this.pageDiv.off("click", "button");
        this.pageDiv.on("click", "button", function () {
            var value = $(this).text();
            var index = Page.options.index;
            if ("上一页" == value && Page.options.index > 1) {
                index = Number(Page.options.index) - 1;
            } else if ("下一页" == value && Page.options.index < Page.options.total) {  
                index = Number(Page.options.index) + 1;
            } else if ("GO" == value) {
                var go = Page.pageDiv.find("input.size");
                var n = go.val();
                if (!isNaN(n) && n >= 1 && n <= Page.options.total) {
                    index = Math.floor(n); //闃叉杈撳叆灏忔暟
                    debugger
                }
                go.val("");
            } else if (!isNaN(value)) { //鐐瑰嚮椤电爜
                index = value;
            }
            //褰撻〉鐮佸彂鐢熷彉鍖�
            if (Page.options.index != index) {
                Page.options.index = index;
                options["index"] = Number(Page.options.index);
                //璋冪敤鍥炶皟鍑芥暟
                callback(options);
                //閲嶆柊娓叉煋鍒嗛〉
                Page.render();
            }
        });
    },
    /**
     * 娓叉煋鍒嗛〉
     */
    render: function () {

        /*-----------------DOM娓叉煋--------------------*/
        var s = '<button type="submit" class="prevPage">上一页</button>';

        if (this.options.total <= this.options.numbers) { //鎬婚〉鏁板皬浜庣瓑浜庡彲鏄剧ず椤电爜鏁帮紝鍏ㄩ儴鏄剧ず
            for (var i = 1; i <= this.options.total; i++) {
                s += '<button type="submit">' + i + '</button>';
            }
        } else { //鎬婚〉鏁板ぇ浜庡彲鏄剧ず椤电爜鏁�
            if (this.options.index <= this.options.numbers - 3) { //鎵€閫夐〉鐮佸湪鍙樉绀洪〉鐮佹暟鐨�...鍓嶄竴浣嶄箣鍓�
                for (var i = 1; i <= this.options.numbers - 2; i++) {
                    s += '<button type="submit">' + i + '</button>';
                }
                s += '<button type="submit" class="pageMore">...</button>';
                s += '<button type="submit">' + this.options.total + '</button>';
            } else if (this.options.index >= this.options.total - (this.options.numbers -
                4)) {
                s += '<button type="submit">1</button>';
                s += '<button type="submit" class="pageMore">...</button>';
                for (var i = this.options.total - (this.options.numbers - 3) ; i <=
                  this.options.total; i++) {
                    s += '<button type="submit">' + i + '</button>';
                }
            } else {
                s += '<button type="submit">1</button>';
                s += '<button type="submit" class="pageMore">...</button>';
                var offset = Math.floor((this.options.numbers - 4) / 2);
                for (var i = this.options.index - offset; i <= Number(this.options.index) +
                  offset; i++) {
                    s += '<button type="submit">' + i + '</button>';
                }
                s += '<button type="submit" class="pageMore">...</button>';
                s += '<button type="submit">' + this.options.total + '</button>';
            }
        }

        s +=
          '<span class="sizePar">第<input type="text" class="size">页</span><button type="submit" class="Go">GO</button>';
        s += '<button type="submit" class="nextPage">下一页</button>';
        //灏嗗厓绱犳坊鍔犲埌椤甸潰
        this.pageDiv.html(s);

        /*-----------------鏍峰紡娓叉煋--------------------*/
        //閫変腑椤电爜
        Page.pageDiv.find("button").each(function () {
            if ($(this).text() == Page.options.index) {
                $(this).addClass("active");
            }
        });
        //上一页
        if (this.options.index > 1) {
            Page.pageDiv.find("button.prevPage").removeClass("disabled");
        } else {
            Page.pageDiv.find("button.prevPage").addClass("disabled");
        }
        //下一页
        if (this.options.index < this.options.total) {
            Page.pageDiv.find("button.nextPage").removeClass("disabled");
        } else {
            Page.pageDiv.find("button.nextPage").addClass("disabled");
        }
    }
}
