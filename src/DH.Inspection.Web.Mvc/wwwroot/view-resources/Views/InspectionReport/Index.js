(function ($) {
    var _inspectionReportService = abp.services.app.inspectionsAppServer,
        l = abp.localization.getSource('Inspection'),
        _$modal = $('#TenantCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#InspectionReportTable');

    var _$inspectionReportsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#InspectionReportSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _inspectionReportService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$inspectionReportsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        //处理每行数据
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'phone',
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-inspectionReport" data-inspectionReport-id="${row.id}" data-toggle="modal" data-target="#TenantEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-inspectionReport" data-inspectionReport-id="${row.id}" data-tenancy-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var inspectionReport = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _inspectionReportService
            .create(inspectionReport)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$inspectionReportsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-inspectionReport', function () {
        var inspectionReportId = $(this).attr('data-inspectionReport-id');
        var tenancyName = $(this).attr('data-tenancy-name');

        deleteTenant(inspectionReportId, tenancyName);
    });

    $(document).on('click', '.edit-inspectionReport', function (e) {
        var inspectionReportId = $(this).attr('data-inspectionReport-id');

        abp.ajax({
            url: abp.appPath + 'InspectionReport/EditModal?inspectionReportId=' + inspectionReportId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TenantEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('inspectionReport.edited', (data) => {
        _$inspectionReportsTable.ajax.reload();
    });

    function deleteTenant(inspectionReportId, tenancyName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                tenancyName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _inspectionReportService
                        .delete({
                            id: inspectionReportId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$inspectionReportsTable.ajax.reload();
                        });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$inspectionReportsTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$inspectionReportsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$inspectionReportsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
