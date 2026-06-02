let currentContactId = null;
let modal = null;

$(document).ready(function () {
    modal = new bootstrap.Modal(document.getElementById('contactModal'));
    loadContacts();

    $('#addContactBtn').click(function () {
        resetForm();
        $('#modalTitle').text('Add contact');
        currentContactId = null;
        modal.show();
    });

    $('#saveBtn').click(function () {
        if (validateForm()) {
            // Base object 
            const contact = {
                name: $('#name').val().trim(),
                mobilePhone: $('#mobilePhone').val().trim() || null,
                jobTitle: $('#jobTitle').val().trim() || null,
                birthDate: $('#birthDate').val() || null
            };
            if (currentContactId) {
                contact.id = currentContactId;
                updateContact(contact);
            } else {
                createContact(contact);
            }
        }
    });
});

function loadContacts() {
    $.ajax({
        url: '/api/contacts',
        method: 'GET',
        success: function (data) {
            renderContacts(data);
        },
        error: function () {
            alert('Error loading contacts');
        }
    });
}

function renderContacts(contacts) {
    const tbody = $('#contactsBody');
    tbody.empty();
    contacts.forEach(c => {
        const birth = c.birthDate ? new Date(c.birthDate).toLocaleDateString() : '';
        const row = `
            <tr>
                <td>${c.id}</td>
                <td>${escapeHtml(c.name)}</td>
                <td>${escapeHtml(c.mobilePhone || '')}</td>
                <td>${escapeHtml(c.jobTitle || '')}</td>
                <td>${birth}</td>
                <td>
                    <button class="btn btn-sm btn-warning edit-btn" data-id="${c.id}">✏️ Add</button>
                    <button class="btn btn-sm btn-danger delete-btn" data-id="${c.id}">🗑️ Delete</button>
                </td>
            </tr>
        `;
        tbody.append(row);
    });
    $('.edit-btn').click(function () {
        const id = $(this).data('id');
        editContact(id);
    });
    $('.delete-btn').click(function () {
        const id = $(this).data('id');
        if (confirm('Delete contact?')) deleteContact(id);
    });
}

function editContact(id) {
    $.ajax({
        url: `/api/contacts/${id}`,
        method: 'GET',
        success: function (contact) {
            currentContactId = contact.id;
            $('#contactId').val(contact.id);
            $('#name').val(contact.name);
            $('#mobilePhone').val(contact.mobilePhone || '');
            $('#jobTitle').val(contact.jobTitle || '');
            $('#birthDate').val(contact.birthDate ? contact.birthDate.split('T')[0] : '');
            $('#modalTitle').text('Edit contact');
            modal.show();
        },
        error: function () {
            alert('Error loading contact data');
        }
    });
}

function createContact(contact) {
    $.ajax({
        url: '/api/contacts',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(contact),
        success: function () {
            modal.hide();
            loadContacts();
            resetForm();
        },
        error: function (xhr) {
            handleServerError(xhr);
        }
    });
}

function updateContact(contact) {
    $.ajax({
        url: `/api/contacts/${contact.id}`,
        method: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(contact),
        success: function () {
            modal.hide();
            loadContacts();
            resetForm();
        },
        error: function (xhr) {
            handleServerError(xhr);
        }
    });
}

function deleteContact(id) {
    $.ajax({
        url: `/api/contacts/${id}`,
        method: 'DELETE',
        success: function () {
            loadContacts();
        },
        error: function () {
            alert('Deletion error');
        }
    });
}

function validateForm() {
    let isValid = true;
    const name = $('#name').val().trim();
    const phone = $('#mobilePhone').val().trim();
    const birthDate = $('#birthDate').val();

    if (!name || name.length > 100) {
        $('#name').addClass('is-invalid');
        isValid = false;
    } else {
        $('#name').removeClass('is-invalid');
    }

    if (phone && !/^\+?[0-9]{10,15}$/.test(phone)) {
        $('#mobilePhone').addClass('is-invalid');
        isValid = false;
    } else {
        $('#mobilePhone').removeClass('is-invalid');
    }

    if (birthDate) {
        const date = new Date(birthDate);
        const minDate = new Date('1900-01-01');
        const today = new Date();
        today.setHours(0, 0, 0, 0);
        if (date > today || date < minDate) {
            $('#birthDate').addClass('is-invalid');
            isValid = false;
        } else {
            $('#birthDate').removeClass('is-invalid');
        }
    } else {
        $('#birthDate').removeClass('is-invalid');
    }

    return isValid;
}

function resetForm() {
    $('#contactForm')[0].reset();
    $('#contactId').val('');
    $('#name, #mobilePhone, #birthDate').removeClass('is-invalid');
    currentContactId = null;
}

function handleServerError(xhr) {
    if (xhr.status === 400 && xhr.responseJSON && xhr.responseJSON.errors) {
        const errors = xhr.responseJSON.errors;
        let errorMsg = 'Validation error:\n';
        for (const key in errors) {
            errorMsg += `${key}: ${errors[key].join(', ')}\n`;
        }
        alert(errorMsg);
    } else {
        alert('Unknown error. Check data.');
    }
}

function escapeHtml(str) {
    return str.replace(/[&<>]/g, function (m) {
        if (m === '&') return '&amp;';
        if (m === '<') return '&lt;';
        if (m === '>') return '&gt;';
        return m;
    });
}