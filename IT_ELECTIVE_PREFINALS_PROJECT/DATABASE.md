## Ticket Ecosystem Schema (Member 2 - Sabesaje)

### `TicketCategories`
- `category_id` (INTEGER, PK, Auto Increment)
- `category_name` (TEXT, Required, Max 100)
- `parent_category_id` (INTEGER, FK to `TicketCategories.category_id`, Nullable)

### `Tags`
- `tag_id` (INTEGER, PK, Auto Increment)
- `tag_name` (TEXT, Required, Max 50)
- `color_code` (TEXT, Nullable, Max 20)

### `Tickets`
- `ticket_id` (INTEGER, PK, Auto Increment)
- `title` (TEXT, Required, Max 150)
- `description` (TEXT, Nullable)
- `status` (TEXT, Required, Default 'Open')
- `priority` (TEXT, Required, Default 'Medium')
- `customer_id` (INTEGER, FK to `Customers.customer_id`)
- `category_id` (INTEGER, FK to `TicketCategories.category_id`)
- `created_at` (DATETIME, Default Current Timestamp)
- `updated_at` (DATETIME, Nullable)

### `TicketAssignments`
- `ticket_id` (INTEGER, FK to `Tickets.ticket_id`, Composite PK Part 1)
- `employee_id` (INTEGER, FK to `Employees.employee_id`, Composite PK Part 2)
- `assigned_at` (DATETIME, Default Current Timestamp)
- `is_primary` (BOOLEAN, Default 0)

### `TicketComments`
- `comment_id` (INTEGER, PK, Auto Increment)
- `ticket_id` (INTEGER, FK to `Tickets.ticket_id`)
- `author_employee_id` (INTEGER, FK to `Employees.employee_id`, Nullable)
- `author_customer_id` (INTEGER, FK to `Customers.customer_id`, Nullable)
- `comment_body` (TEXT, Required)
- `created_at` (DATETIME, Default Current Timestamp)
- `is_internal_note` (BOOLEAN, Default 0)

### `TicketTags`
- `ticket_id` (INTEGER, FK to `Tickets.ticket_id`, Composite PK Part 1)
- `tag_id` (INTEGER, FK to `Tags.tag_id`, Composite PK Part 2)

### `TicketAttachments`
- `attachment_id` (INTEGER, PK, Auto Increment)
- `ticket_id` (INTEGER, FK to `Tickets.ticket_id`)
- `file_name` (TEXT, Required, Max 255)
- `file_path` (TEXT, Required, Max 500)
- `file_size_kb` (INTEGER, Nullable)
- `uploaded_at` (DATETIME, Default Current Timestamp)