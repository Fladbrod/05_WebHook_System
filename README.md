# Exposee

The Exposee service allows for the registration and triggering of webhooks based on specific event types related to payment and invoice processes.

### Getting Started

To integrate with the Exposee service, you will need to follow these steps:

### Register a Webhook

To register a webhook, send a `POST` request to the `/api/Webhook/register` endpoint with the following payload:

```json
{
  "url": "<Your Webhook URL>",
  "eventTypes": [
    "PaymentReceived",
    "PaymentProcessed",
    "InvoiceGenerated",
    "InvoiceSent"
  ]
}
```

You will receive a response containing a unique identifier for your webhook subscription:
```json
{
  "id": "Guid"
}
```

### Unregister a Webhook
To unregister a webhook, send a DELETE request to the /api/Webhook/unregister/{id} endpoint, where {id} is the unique identifier you received during registration.

### Trigger an Event
To simulate an event and trigger registered webhooks, send a POST request to the /api/Event/trigger/{eventType} endpoint, where {eventType} is one of the predefined event types.

### Ping Webhooks
You can test that your integration can call and receive webhooks by sending a POST request to the /api/Webhook/ping endpoint. This will trigger all registered webhooks for the test event.

### Event Types
The following event types are supported:
* PaymentReceived
* PaymentProcessed
* InvoiceGenerated
* InvoiceSent

# Integrator

### Subscribing to Webhook endpoint
![Webhook image](images/Subscribe-alert.jpg)

### Unsubscribing to Webhook endpoint
![Webhook image](images/Unsubscribe-alert.jpg)

In swagger when calling the endpoint to unsubscribe to alert:

![Webhook image](images/Unsubscribe-alert-success.jpg)

### Triggering an event through /ping:
![Ping image](images/Ping-success.jpg)

Receive endpoint:

![Receive image](images/Receive-endpoint.jpg)

Output:

![Output image](images/Ping-response.jpg)

![Output image](images/http-requests.jpg)