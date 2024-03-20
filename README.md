# Exposee

The Exposee service allows for the registration and triggering of webhooks based on specific event types related to payment and invoice processes.

## Getting Started

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
* PaymentInitiated
* PaymentReceived
* PaymentProcessed
* InvoiceGenerated
* InvoiceSent

# Integrator
