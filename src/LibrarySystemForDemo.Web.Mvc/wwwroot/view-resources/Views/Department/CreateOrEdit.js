/*  For Departments > CreateOrEdit   */
(function ($) {

    var _departmentService = abp.services.app.department,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=DepartmentForm]');

    _$form.find('.save-button').on('click', (e) => {
        save();
    })

    _$form.find('.cancel-button').on('click', (e) => {
        cancelAndReturn();
    })

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var department = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (department.Id != 0) //Not Empty > Then > Update or Edit
        {
            _departmentService.update(department).done(function () {
                redirectToDepartmentIndex();
                abp.message.success('Successfully Updated!', 'Updated');
            });
        }
        else //Department Id has Value > Then > Create 
        {
            _departmentService.create(department).done(function () {
                redirectToDepartmentIndex();
                abp.message.success('Successfully Saved!', 'Saved');
            });
        }

    }

    function redirectToDepartmentIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = "/Department";

    }

    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = "/Department";
                }
            });
    }


})(jQuery);