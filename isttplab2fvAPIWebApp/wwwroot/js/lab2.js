const uri = 'api/Factories';
let factories = [];

function getFactories() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFactories(data))
        .catch(error => console.error('Unable to get factories.', error));
}

function addFactory() {
    const addAdressTextbox = document.getElementById('add-adress');
    const addMaintenanceTextbox = document.getElementById('add-maintenance');
    const addFactoryNameTextbox = document.getElementById('add-factoryName');

    const factory = {
        adress: addAdressTextbox.value.trim(),
        maintenance: addMaintenanceTextbox.value.trim(),
        factoryName: addFactoryNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(factory)
    })
        .then(response => response.json())
        .then(() => {
            getFactories();
            addAdressTextbox.value = '';
            addMaintenanceTextbox.value = '';
            addFactoryNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add factory.', error));
}

function deleteFactory(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFactories())
        .catch(error => console.error('Unable to delete factory.', error));
}

function displayEditForm(id) {
    const factory = factories.find(factory => factory.id === id);

    document.getElementById('edit-id').value = factory.id;
    document.getElementById('edit-adress').value = factory.adress;
    document.getElementById('edit-maintenance').value = factory.maintenance;
    document.getElementById('edit-factoryName').value = factory.factoryName;
    document.getElementById('editForm').style.display = 'block';
}

function updateFactory() {
    const factoryId = document.getElementById('edit-id').value;
    const factory = {
        id: parseInt(factoryId, 10),
        adress: document.getElementById('edit-adress').value.trim(),
        maintenance: document.getElementById('edit-maintenance').value.trim(),
        factoryName: document.getElementById('edit-factoryName').value.trim()
    };

    fetch(`${uri}/${factoryId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(factory)
    })
        .then(() => getFactories())
        .catch(error => console.error('Unable to update factory.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayFactories(data) {
    const tBody = document.getElementById('factories');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(factory => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${factory.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFactory(${factory.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(factory.adress);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeMaintenance = document.createTextNode(factory.maintenance);
        td2.appendChild(textNodeMaintenance);

        let td3 = tr.insertCell(2);
        let textNodeFactoryName = document.createTextNode(factory.factoryName);
        td3.appendChild(textNodeFactoryName);

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    factories = data;
}
