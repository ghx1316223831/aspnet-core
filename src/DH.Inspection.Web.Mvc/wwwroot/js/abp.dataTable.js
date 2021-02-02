var abp = abp || {};
(function () {
    if (!$.fn.dataTable) {
        return;
    }

    abp.libs = abp.libs || {};
    var l = abp.localization.getSource("Inspection");

    var language = {
        emptyTable: "暂无数据",
        info: "_START_-_END_ 列 _TOTAL_ 行",
        infoEmpty: "没有记录",
        infoFiltered: "(筛选自 _MAX_ 总条目数)", //
        infoPostFix: "",
        infoThousands: ",",
        lengthMenu: "显示 _MENU_ 分页",
        loadingRecords: "加载中...",
        processing: '<i class="fas fa-refresh fa-spin"></i>',
        search: "Search:",
        zeroRecords: "找不到匹配的记录",
        paginate: {
            first: '<i class="fas fa-angle-double-left"></i>',
            last: '<i class="fas fa-angle-double-right"></i>',
            next: '<i class="fas fa-chevron-right"></i>',
            previous: '<i class="fas fa-chevron-left"></i>'
        },
        aria: {
            sortAscending: ": 激活以对列升序排序",
            sortDescending: ": 激活以对列升序排序"
        }
    };

    $.extend(true, $.fn.dataTable.defaults, {
        searching: false,
        ordering: false,
        language: language,
        processing: true,
        autoWidth: false,
        responsive: true,
        dom: [
            "<'row'<'col-md-12'f>>",
            "<'row'<'col-md-12't>>",
            "<'row mt-2'>",
            "<'col-lg-1 col-xs-12'<'float-left text-center data-tables-refresh'B>>",
            "<'col-lg-3 col-xs-12'<'float-left text-center'i>>",
            "<'col-lg-3 col-xs-12'<'text-center'l>>",
            "<'col-lg-5 col-xs-12'<'float-right'p>>",
            ">"
        ].join('')
    });
})();
