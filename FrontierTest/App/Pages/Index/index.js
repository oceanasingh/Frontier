

$(document).ready(function () {

    var frontierVue = new Vue({
        el: '#account-grid',
        data: {
            activeList: frontier.Data.filter(function (e) {
                return e.AccountStatusId == 0;
            }),
            inactiveList: frontier.Data.filter(function (e) {
                return e.AccountStatusId == 1;
            }),
            overdueList: frontier.Data.filter(function (e) {
                return e.AccountStatusId == 2;
            }),

        },
        filters: {
            currencyFormatter: function (value) {
                var formatter = new Intl.NumberFormat('en-US', {
                    style: 'currency',
                    currency: 'USD',
                });
                return formatter.format(value);
            },

            formatPhone: function (value) {
                return formatPhoneNumber(value);
            },
            formatDate: function (value) {
                if (value) {
                    return moment(String(value)).format('MM/DD/YYYY');
                }
            },
            formatName: function (Id) {
                if (Id) {
                    var filterObj = frontier.Data.filter(function (e) {
                        return e.Id == Id;
                    });
                    if (filterObj)
                        return filterObj[0].FirstName + " " + filterObj[0].LastName;
                    else
                        return "";
                }
            }

        }
    });

});

function formatPhoneNumber(phoneNumberString) {
    var cleaned = ('' + phoneNumberString).replace(/\D/g, '')
    var match = cleaned.match(/^(1|)?(\d{3})(\d{3})(\d{4})$/)
    if (match) {
        var intlCode = (match[1] ? '+1 ' : '')
        return [intlCode, '(', match[2], ') ', match[3], '-', match[4]].join('')
    }
    return null
}